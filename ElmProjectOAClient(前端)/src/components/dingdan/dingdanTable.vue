<template>
  <div>
    <el-table :data="list" stripe>
      <el-table-column label="订单编号" min-width="50" prop="id"></el-table-column>
      <el-table-column label="用户编号" min-width="50" prop="userid"></el-table-column>
      <el-table-column label="骑手编号" min-width="50" prop="riderid"></el-table-column>
      <el-table-column label="送出时间" min-width="70" prop="deliverytime"></el-table-column>
      <el-table-column label="送达时间" min-width="70" prop="servicetime"></el-table-column>
      <el-table-column label="货主名称" min-width="50" prop="nameofshipper"></el-table-column>
      <el-table-column label="联系电话" min-width="70" prop="contactnumber"></el-table-column>
      <el-table-column label="收货地址" min-width="150" prop="receivingaddress"></el-table-column>
      <el-table-column label="红包抵扣" min-width="50" prop="redenvelopededuction"></el-table-column>
      <el-table-column label="订单消费合计" min-width="50" prop="totalorderconsumption"></el-table-column>
      <el-table-column label="操作" min-width="100">
        <template v-slot="scope">
          <div :key="scope.row.Id">
            <el-button
              type="warning"
              size="small"
              plain
              round
              icon="el-icon-edit"
              @click="reset(scope.row)"
            >修改</el-button>
            <el-button
              type="danger"
              @click="deleteCategory(scope.$index)"
              size="small"
              icon="el-icon-delete"
              plain
              round
            >删除</el-button>
          </div>
        </template>
      </el-table-column>
    </el-table>
  </div>
</template>
<script>
import axios from "axios";

export default {
  data() {
    return {
      list: [],
      keyword: ""
    };
  },
  mounted() {
    this.loadData();
  },
  methods: {
    reset(row) {
      this.$loading({ text: "wait a moment plz" });
      this.$emit("xiugai", row);
      this.$loading().close();
    },

    //加载数据(AJAX请求)(传关键词和不穿要判断)
    loadData(k) {
      this.$loading({ text: "查询中,请稍等" });
      if (k != undefined) {
        this.keyword = k;
        axios
          .get("/rng/Orderform/Search", {
            params: {
              Id: this.keyword
            }
          })
          .then(res => {
            this.list = res.data.RelateData;
            this.$loading().close();
            this.$message({
              message: "查询成功",
              type: "success"
            });
          });
      } else {
        console.log(1);
        axios.get("/rng/Orderform/Load").then(res => {
          this.list = res.data.RelateData;
          this.$loading().close();
          this.$message({
            message: "加载成功",
            type: "success"
          });
        });
      }
    },
    //删除行（ajax请求，根据ID删除行）
    deleteCategory(index) {
      this.$loading({ text: "删除中,请稍等" });
      console.log(index);
      this.list.splice(index, 1);
      this.$loading().close();
      this.$message({
        message: "删除成功",
        type: "success"
      });
    }
  }
};
</script>