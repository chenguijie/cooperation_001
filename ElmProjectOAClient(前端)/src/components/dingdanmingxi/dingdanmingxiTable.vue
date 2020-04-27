<template>
  <div>
    <el-table :data="list" stripe>
      <el-table-column label="订单编号" min-width="100" prop="orderid"></el-table-column>
      <el-table-column label="商品编号" min-width="100" prop="commodityid"></el-table-column>
      <el-table-column label="商品单价" min-width="100" prop="itempricing"></el-table-column>
      <el-table-column label="商品数量" min-width="100" prop="quantityofcommodities"></el-table-column>
      <el-table-column label="商品折扣" min-width="100" prop="merchandisediscount"></el-table-column>
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
import Axios from "axios";
//import axios from 'axios'

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
      this.$loading({
        text: "wait a moment plz"
      });
      this.$emit("xiugai", row);
      this.$loading().close();
    },

    //加载数据(AJAX请求)(传关键词和不穿要判断)
    loadData(k) {
      //   this.$loading({ text: "加载中，请稍等" });
      if (k == undefined) {
        this.$loading({ text: "加载中,请稍等" });
        Axios.get("/rng/OrderDetails/Load").then(res => {
          this.list = res.data.RelateData;
          this.$loading().close();
          this.$message({
            message: "加载成功",
            type: "success"
          });
        });
      } else {
        this.$loading({ text: "查询中,请稍等" });
        Axios.get("/rng/OrderDetails/Search", { params: { Id: k } }).then(
          res => {
            this.list = res.data.RelateData;
            this.$loading().close();
            this.$message({
            message: "查询成功",
            type: "success"
          });
          }
        );
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