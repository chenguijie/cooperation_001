<template>
  <el-dialog :title="title" :visible.sync="visible" width="400px" :close-on-click-modal="false">
    <el-form :model="form" ref="form" label-width="80px">
      <el-form-item label="用户编号">
        <el-input v-model="form.userid" placeholder="请输入用户编号"></el-input>
      </el-form-item>
      <el-form-item label="货主名称">
        <el-input v-model="form.nameofshipper" placeholder="请输入货主名称"></el-input>
      </el-form-item>
      <el-form-item label=" 收货地址">
        <el-input v-model="form.receivingaddress" placeholder="请输入收货地址"></el-input>
      </el-form-item>
      <el-form-item label="经度">
        <el-input v-model="form.longitudeofreceivingaddress" placeholder="请输入经度"></el-input>
      </el-form-item>
      <el-form-item label="纬度">
        <el-input v-model="form.receivingaddresslatitude" placeholder="请输入纬度"></el-input>
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
        nameofshipper: "",
        receivingaddress: "",
        receivingaddresslatitude: "",
        longitudeofreceivingaddress: ""
      }
    };
  },
  methods: {
    openAddDialog() {
      this.title = "添加收货地址数据";
      this.form = {
        userid: "",
        nameofshipper: "",
        receivingaddress: "",
        receivingaddresslatitude: "",
        longitudeofreceivingaddress: ""
      };
      this.visible = true;

      setTimeout(() => {
        this.$refs.form.resetFields();
      }, 1000);
    },
    openeditdialog(data) {
      this.title = "修改收货地址数据";
      console.log(13);
      console.log(data);
      this.form = data;
      this.visible = true;
    },
    ok() {
      console.log(14);
      var formData = new FormData();
      var url = "";
      if (this.form.id == undefined) {
        console.log(14.1);
        url = "/rng/Userreceivingaddresstable/Add";
      } else {
        console.log(14.2);
        url = "/rng/Userreceivingaddresstable/Reset";
        formData.append("Id", this.form.id);
      }
      this.$refs.form.validate(result => {
        if (result) {
          this.$loading({ text: "正在上传" });
          
          
          formData.append("UserId",this.form.userid);
          formData.append("Nameofshipper",this.form.nameofshipper);
          formData.append("Receivingaddress",this.form.receivingaddress);
          formData.append("Receivingaddresslatitude",this.form.receivingaddresslatitude);
          formData.append("Longitudofreceivingaddress",this.form.longitudeofreceivingaddress);
          //下一步发起ajax请求
          Axios.post(url, formData).then(res => {
            this.$loading().close();
            if (res.data.success) {
              this.visible = false;
              this.$emit("refresh");
            }
            this.$message({
              message: res.data.message,
              type: res.data.success ? "success" : "error"
            });
          });
          this.$loading().close();
        }
      });
    }
  }
};
</script>