<template>
  <el-dialog :title="title" :visible.sync="visible" width="500px" :close-on-click-modal="false"> 
    <el-form :model="form" ref="form" label-width="100px">
      <el-form-item label="用户编号">
        <el-input v-model="form.userid" placeholder="请输入用户编号"></el-input>
      </el-form-item>
      <el-form-item label="骑手编号">
        <el-input v-model="form.riderid " placeholder="请输入骑手编号"></el-input>
      </el-form-item>
      <el-form-item label="下单时间">
        <el-input v-model="form.ordertime " placeholder="请输入下单时间"></el-input>
      </el-form-item>
      <el-form-item label="送出时间 ">
        <el-input v-model="form.deliverytime " placeholder="请输入送出时间"></el-input>
      </el-form-item>
      <el-form-item label="送达时间">
        <el-input v-model="form.servicetime " placeholder="请输入送达时间"></el-input>
      </el-form-item>
       <el-form-item label="货主名称">
        <el-input v-model="form.nameofshipper " placeholder="请输入货主名称"></el-input>
      </el-form-item>
      <el-form-item label="联系电话">
        <el-input v-model="form.contactnumber " placeholder="请输入联系电话"></el-input>
      </el-form-item>
      <el-form-item label="收货地址">
        <el-input v-model="form.receivingaddress " placeholder="请输入收货地址"></el-input>
      </el-form-item>
      <el-form-item label="收货地址经度">
        <el-input v-model="form.longitudeofreceivingaddress " placeholder="请输入收货地址经度"></el-input>
      </el-form-item>
      <el-form-item label="收货地址纬度">
        <el-input v-model="form.receivingaddresslatitude " placeholder="请输入收货地址纬度"></el-input>
      </el-form-item>
      <el-form-item label="红包抵扣">
        <el-input v-model="form.redenvelopededuction " placeholder="请输入红包抵扣"></el-input>
      </el-form-item>
      <el-form-item label="订单消费合计">
        <el-input v-model="form.totalorderconsumption " placeholder="请输入订单消费合计"></el-input>
      </el-form-item>
    </el-form>
    <template v-slot:footer>
      <el-button type="warning" @click="visible=false">取消</el-button>
      <el-button type="primary" @click="ok">确定</el-button>
    </template>
  </el-dialog>
</template>
<script>
import Axios from "axios";
export default {
  data() {
    return {
      visible: false,
      title: "title",

      form: {
        userid: "",
        riderid: "",
        ordertime: "",
        deliverytime: "",
        servicetime: "",
        nameofshipper: "",
        contactnumber: "",
        receivingaddress: "",
        longitudeofreceivingaddress: "",
        receivingaddresslatitude: "",
        redenvelopededuction: "",
        totalorderconsumption: ""
      }
    };
  },
  methods: {
    openeditdialog(data){
      this.title = "修改订单数据";
      this.form=data;
      this.visible=true;
      console.log(this.form)
    },
    openAddDialog() {
      this.form= {
        userid: "",
        riderid: "",
        ordertime: "",
        deliverytime: "",
        servicetime: "",
        nameofshipper: "",
        contactnumber: "",
        receivingaddress: "",
        longitudeofreceivingaddress: "",
        receivingaddresslatitude: "",
        redenvelopededuction: "",
        totalorderconsumption: ""
      }
      this.title = "添加订单数据";
      this.visible = true;

      setTimeout(() => {
        document.getElementById("xx").value = undefined;
        this.$refs.form.resetFields();
      }, 1000);
    },
    ok() {
      var formData = new FormData();
      var url = "";
      if (this.form.id == undefined) {
        url = "/rng/Orderform/Add";
      } else {
        url = "/rng/Orderform/Reset";
        formData.append("Id", this.form.id);
      }
      this.$refs.form.validate(result => {
        if (result) {
          this.$loading({ text: "正在上传" });
          formData.append("UserId", this.form.userid);
          formData.append("RiderId", this.form.riderid);
          formData.append("Ordertime", this.form.ordertime);
          formData.append("Deliverytime", this.form.deliverytime);
          formData.append("Servicetime", this.form.servicetime);
          formData.append("Nameofshipper", this.form.nameofshipper);
          formData.append("Contactnumber", this.form.contactnumber);
          formData.append("Receivingaddress", this.form.receivingaddress);
          formData.append("Longitudeofreceivingaddress", this.form.longitudeofreceivingaddress);
          formData.append("Receivingaddresslatitude", this.form.receivingaddresslatitude);
          formData.append("Redenvelopededuction", this.form.redenvelopededuction);
          formData.append("Totalorderconsumption", this.form.totalorderconsumption);

          //下一步发起ajax请求
          Axios.post(url, formData).then(r => {
            if (r.data.success) {
              this.visible = false;
              this.$emit("refresh");
            }
            this.$message({
              message: r.data.message,
              type: r.data.success ? "success" : "error"
            });
          });
          this.$loading().close();
        }
      });
      this.$emit("refresh");
    }
  }
};
</script>