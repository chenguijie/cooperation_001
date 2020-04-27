<template>
    <div>
        <basic-toolbar @refresh="onFresh" @add="onAdd" @search="onSearch"></basic-toolbar>
        <dingdan-table ref="table" @xiugai="onxiugai"></dingdan-table>
        <dingdan-dialog  @refresh="onFresh" ref="dialog"></dingdan-dialog>
    </div>
</template>
<script>
import basicToolbar from './public/basicToolbar'
import dingdanDialog from './dingdan/dingdanDialog'
import dingdanTable from './dingdan/dingdanTable'

export default {
    components:{
        basicToolbar,
        dingdanDialog,
        dingdanTable
    },
    methods:{
        onxiugai(data){
            var xin = JSON.parse(JSON.stringify(data));
       this.$refs.dialog.openeditdialog(xin);
        },
        onFresh(){
            this.$refs.table.loadData()
        },
        onAdd(){
            this.$refs.dialog.openAddDialog()
        },
        onSearch(k){
             //请求ajax后添加keyword
            this.$refs.table.loadData(k)
        }
    }
}
</script>