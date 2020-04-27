<template>
  <div>
    <abc @refresh="onFresh" @add="onAdd" @search="onSearch"></abc>
    <bbc ref="table" @xiugai="onxiugai"></bbc>
    <ccc @refresh="onFresh" ref="dialog"></ccc>
  </div>
</template>
<script>
import abc from "./public/basicToolbar";
import bbc from "./shouhuodizhi/shouhuodizhiTable";
import ccc from "./shouhuodizhi/shouhuodizhiDialog";
export default {
  components: {
    abc,
    bbc,
    ccc
  },
  methods: {
    onxiugai(data) {
      console.log(12);
      var xin = JSON.parse(JSON.stringify(data));
      console.log(xin);
      this.$refs.dialog.openeditdialog(xin);
      
    },
    onFresh() {
      this.$refs.table.loadData();
    },
    onAdd() {
      this.$refs.dialog.openAddDialog();
    },
    onSearch(k) {
      //请求ajax后添加keyword
      this.$refs.table.loadData(k);
    }
  }
};
</script>