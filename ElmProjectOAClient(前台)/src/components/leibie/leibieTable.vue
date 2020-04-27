<template>
  <div>
    <el-table :data="list" stripe>
      <el-table-column prop="id" label="类别编号" min-width="50"></el-table-column>
      <el-table-column prop="categoryname" label="类别名称" min-width="50"></el-table-column>
      <el-table-column prop="classdescription" label="类别描述" min-width="100"></el-table-column>
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
      axios.get("/rng/Classtable/Load", {}).then(res => {
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
      axios.get("/rng/Classtable/Search", {
          params: {
            id: k
          }
        }).then(res => {
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