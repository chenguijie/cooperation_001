<template>
  <el-dialog :title="title" :visible.sync="visible" width="500px" :close-on-click-modal="false">
    <el-form :model="form" ref="form" label-width="80px" >
      <el-form-item label="订单编号">
        <el-input v-model="form.orderid" placeholder="请输入订单编号"></el-input>
      </el-form-item>
      <el-form-item label="商品编号">
        <el-input v-model="form.commodityid" placeholder="请输入商品编号"></el-input>
      </el-form-item>
      <el-form-item label="商品单价">
        <el-input v-model="form.itempricing" placeholder="请输入商品单价"></el-input>
      </el-form-item>
      <el-form-item label="商品数量">
        <el-input v-model="form.quantityofcommodities" placeholder="请输入商品数量"></el-input>
      </el-form-item>
      <el-form-item label="商品折扣">
        <el-input v-model="form.merchandisediscount " placeholder="请输入商品折扣"></el-input>
      </el-form-item>
    </el-form>
    <template v-slot:footer>
      <el-button type="warning" @click="visible=false">取消</el-button>
      <el-button type="primary" @click="ok">确定</el-button>
    </template>
  </el-dialog>
  
</template>
<script>
import Axios from 'axios';
export default {
  data() {
    return {
      visible: false,
      title: "title",
      
      form: {
        orderid: "",
        commodityid: "",
        itempricing: "",
        quantityofcommodities: "",
        merchandisediscount: ""
      }
    };
  },
  methods: {
    openeditdialog(data) {
      this.title = "修改订单明细数据";
      console.log(13);
      this.form = data;
      this.visible = true;
    },
    openAddDialog() {
      this.title = "添加订单明细数据";
      this.form= {
        orderid: "",
        commodityid: "",
        itempricing: "",
        quantityofcommodities: "",
        merchandisediscount: ""
      }
      this.visible = true;

      setTimeout(() => {
          document.getElementById("xx").value="";
        this.$refs.form.resetFields();
      }, 1000);
    },
    ok() {
      var formData = new FormData();
      var url=""
      if(this.form.id==undefined){
        url = "/rng/OrderDetails/Add";
      }else{
        url = "/rng/OrderDetails/Reset";
        formData.append("Id", this.form.id);
        
      }
      this.$refs.form.validate(result => {
        if (result) {
          this.$loading({ text: "正在上传" });
          formData.append("Orderid", parseInt(this.form.orderid));
          formData.append("Commodityid", this.form.commodityid);
          formData.append("Itempricing", this.form.itempricing);
          formData.append("Quantityofcommodities", this.form.quantityofcommodities);
          formData.append("Merchandisediscount", this.form.merchandisediscount);
          Axios.post(url,formData).then(res=>{
            if(res.data.success){
              this.visible=false;
              this.$emit("refresh");
            }
            this.$message({
              message: res.data.message,
              type: res.data.success ? "success" : "error"
            });
          })
          this.$loading().close();
        }
      });
      this.$emit("refresh");
    }
  }
};
</script>