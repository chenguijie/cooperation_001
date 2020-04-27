<template>
  <div>
    <tool @add="onadd" @search="onsearch" @refresh="onrefresh"></tool>
    <usertable ref="dialog" @shuaxin="onrefresh"></usertable>
    <jiazai ref="table" @xiugai="onxiugai"></jiazai>
  </div>
</template>
<script>
import tool from './public/basicToolbar'
import jiazai from './yonghu/yonghuTable'
import usertable from './yonghu/yonghuDialog'
export default {
  components: {
    tool,
    usertable,
    jiazai
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