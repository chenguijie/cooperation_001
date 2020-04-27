<template>
  <div>
    <tool @add="onadd" @search="onsearch" @refresh="onrefresh"></tool>
    <shangjiaDialog ref="dialog" @shuaxin="onrefresh"></shangjiaDialog>
    <shangjiaTable ref="table" @xiugai="onxiugai"></shangjiaTable>
  </div>
</template>
<script>
import tool from '../components/public/basicToolbar'
import shangjiaDialog from './shangjia/shangjiaDialog'
import shangjiaTable from './shangjia/shangjiaTable'
export default {
  components: {
    tool,
    shangjiaDialog,
    shangjiaTable
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