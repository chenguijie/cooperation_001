<template>
  <div>
    <el-table :data="list" stripe>
      <el-table-column prop="id" label="商品编号" min-width="80"></el-table-column>
      <el-table-column prop="merchantid" label="商家编号" min-width="80"></el-table-column>
      <el-table-column prop="categoryid" label="类别编号" min-width="80"></el-table-column>
      <el-table-column prop="tradename" label="商品名称" min-width="80"></el-table-column>
      <el-table-column prop="commoditypictures" label="商品图片" width="200">
        <template v-slot="scope">
          <el-image
            :src="'http://localhost:50826/'+scope.row.commoditypictures"
            fit="contain"
            style="width:100px;height:100px;"
          ></el-image>
        </template>
      </el-table-column>
      <el-table-column prop="commoditydescription" label="商品描述" min-width="120"></el-table-column>
      <el-table-column prop="itempricing" label="商品单价" min-width="80"></el-table-column>
      <el-table-column prop="merchandisediscount" label="商品折扣" min-width="80"></el-table-column>
      <el-table-column prop="commodityinventory" label="商品库存" min-width="80"></el-table-column>
      <el-table-column prop="orderquantity" label="商品订购量" min-width="80"></el-table-column>
      <el-table-column label="操作" width="200">
        <template v-slot="scope">
          <div :key="scope.row.id">
            <el-button
              type="warning"
              @click="resetCategory(scope.row)"
              size="small"
              plain
              round
              icon="el-icon-edit"
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
  mounted() {
    //挂载组件后，立即调用，加载数据
    this.loadData();
  },
  data() {
    return {
      list: []
    };
  },
  methods: {
    loadData() {
      this.$loading({ text: "加载中,请稍等" });
      axios.get("/rng/Commoditylist/Load", {}).then(res => {
        this.list = res.data.RelateData;
        this.$loading().close();
        this.$message({
          message: "加载成功",
          type: "success"
        });
      });
    },
    loadrelatedata(k) {
      this.$loading({ text: "查询中,请稍等" });
      axios
        .get("/rng/Commoditylist/Search", {
          params: {
            id: k
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
    },
    resetCategory(row) {
      this.$loading({ text: "修改中,请稍等" });
      console.log(row);
      this.$emit("xiugai", row);
      this.$loading().close();
    },
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