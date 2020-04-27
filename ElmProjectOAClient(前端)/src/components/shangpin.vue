<template>
  <div>
    <tool @add="onadd" @search="onsearch" @refresh="onrefresh"></tool>
    <shangpinDialog ref="dialog" @shuaxin="onrefresh"></shangpinDialog>
    <shangpinTable ref="table" @xiugai="onxiugai"></shangpinTable>
  </div>
</template>
<script>
import tool from '../components/public/basicToolbar'
import shangpinDialog from './shangpin/shangpinDialog'
import shangpinTable from './shangpin/shangpinTable'
export default {
  components: {
    tool,
    shangpinDialog,
    shangpinTable
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