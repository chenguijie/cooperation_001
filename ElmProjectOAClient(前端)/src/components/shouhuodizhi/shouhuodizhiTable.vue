<template>
  <div>
    <el-table :data="list" stripe>
      <el-table-column label="序号" min-width="60" prop="id"></el-table-column>
      <el-table-column label="用户编号" min-width="60" prop="userid"></el-table-column>
      <el-table-column label="货主名称" min-width="60" prop="nameofshipper"></el-table-column>
      <el-table-column label="收货地址" min-width="150" prop="receivingaddress"></el-table-column>
      <el-table-column label="收货地址经度" min-width="100" prop="longitudeofreceivingaddress"></el-table-column>
      <el-table-column label="收货地址纬度" min-width="100" prop="receivingaddresslatitude"></el-table-column>
      <el-table-column label="操作" min-width="100">
        <template v-slot="scope">
          <div :key="scope.row.Id">
            <el-button
              type="warning"
              size="small"
              plain
              round
              icon="el-icon-edit"
              @click="rbq(scope.row)"
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
    rbq(i) {
      this.$loading({ text: "修改中，请稍等" });
      console.log(i);
      this.$emit("xiugai", i);

      this.$loading().close();
    },

    //加载数据(AJAX请求)(传关键词和不穿要判断)
    loadData(k) {
      this.$loading({ text: "查询中,请稍等" });
      if (k != undefined) {
        axios
          .get("/rng/Userreceivingaddresstable/Search", { params: { id: k } })
          .then(res => {
            this.list = res.data.RelateData;
            this.$loading().close();
            this.$message({
              message: "查询成功",
              type: "success"
            });
          });
      } else {
        this.$loading({ text: "加载中,请稍等" });
        axios.get("/rng/Userreceivingaddresstable/Load", {}).then(res => {
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