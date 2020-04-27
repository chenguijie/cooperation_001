<template>
  <div>
    <tool @add="onadd" @search="onsearch" @refresh="onrefresh"></tool>
    <leibieDialog ref="dialog" @shuaxin="onrefresh"></leibieDialog>
    <leibieTable ref="table" @xiugai="onxiugai"></leibieTable>
  </div>
</template>
<script>
import tool from '../components/public/basicToolbar'
import leibieDialog from './leibie/leibieDialog'
import leibieTable from './leibie/leibieTable'
export default {
  components: {
    tool,
    leibieDialog,
    leibieTable
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