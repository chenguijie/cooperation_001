<template>
  <div>
    <tool @add="onadd" @search="onsearch" @refresh="onrefresh"></tool>
    <qishouDialog ref="dialog" @shuaxin="onrefresh"></qishouDialog>
    <qishouTable ref="table" @xiugai="onxiugai"></qishouTable>
  </div>
</template>
<script>
import tool from '../components/public/basicToolbar'
import qishouDialog from './qishhou/qishouDialog'
import qishouTable from './qishhou/qishouTable'
export default {
  components: {
    tool,
    qishouDialog,
    qishouTable
  },
  methods: {
    onxiugai(data) {
      var xin = JSON.parse(JSON.stringify(data));
       this.$refs.dialog.openeditdialog(xin);
    },
    onadd() {
      this.$refs.dialog.opendialog();
    },
    onsearch(k) {
        this.$refs.table.loadrelatedata(k);
    },
    onrefresh() {
        this.$refs.table.loadData();
    }
  }
};
</script>