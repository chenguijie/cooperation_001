<template>
  <el-dialog :title="title" :visible.sync="visiable" width="500px" :close-on-click-modal="false">
    <el-form :model="form" label-width="100px">
      <el-form-item label="商家编号">
        <el-input v-model="form.id" disabled></el-input>
      </el-form-item>
      <el-form-item label="商家名称">
        <el-input v-model="form.nameofmerchant" placeholder="请输入商家编号"></el-input>
      </el-form-item>
      <el-form-item label="联系电话">
        <el-input v-model="form.businesscontactnumber" placeholder="请输入联系电话"></el-input>
      </el-form-item>
      <el-form-item label="店铺名称">
        <el-input v-model="form.shopname" placeholder="请输入店铺名称"></el-input>
      </el-form-item>
      <el-form-item label="店铺地址 ">
        <el-input v-model="form.shopaddress" placeholder="请输入店铺地址 "></el-input>
      </el-form-item>
      <el-form-item label="店铺地址经度">
        <el-input v-model="form.longitudeofstoreaddress" placeholder="请输入店铺地址经度"></el-input>
      </el-form-item>
      <el-form-item label="店铺地址纬度">
        <el-input v-model="form.storeaddresslatitude" placeholder="请输入店铺地址纬度"></el-input>
      </el-form-item>
    </el-form>

    <template v-slot:footer>
      <el-button @click=" visiable= false">取 消</el-button>
      <el-button type="primary" @click="ok">确 定</el-button>
    </template>
  </el-dialog>
</template>
<script>
import axios from "axios";
export default {
  data() {
    return {
      visiable: false,
      title: "标题",
      form: {
        id: 0,
        nameofmerchant:'',
        businesscontactnumber:'',
        shopname:'',
        shopaddress:'',
        longitudeofstoreaddress:'',
        storeaddresslatitude:''
      }
    };
  },
  methods: {
    opendialog() {
      this.title="添加商家数据"
      this.form = {
        id: 0,
        nameofmerchant:'',
        businesscontactnumber:'',
        shopname:'',
        shopaddress:'',
        longitudeofstoreaddress:'',
        storeaddresslatitude:''
      };
      this.visiable = true;
    },
    openeditdialog(data) {
      this.title="修改商家数据"
      console.log(data);
      this.form = data;
      this.visiable = true;
    },
    ok() {
      //开启全局遮罩
      this.$loading({ text: "正在上传文件" });
      var url = "";
      if (this.form.id == 0) {
        url = "/rng/Merchantlist/Add";
      } else {
        url = "/rng/Merchantlist/Reset";
      }
      //因为要传文件，所以必须用FormData去构建要传递的数据
      var formData = new FormData();
      formData.append("Id", this.form.id);
      formData.append("Nameofmerchant", this.form.nameofmerchant);
      formData.append("Businesscontactnumber", this.form.businesscontactnumber);
      formData.append("Shopname", this.form.shopname);
      formData.append("Shopaddress", this.form.shopaddress);
      formData.append("Longitudeofstoreaddress", this.form.longitudeofstoreaddress);
      formData.append("Storeaddresslatitude", this.form.storeaddresslatitude);

      axios.post(url, formData).then(r => {
        this.$loading().close(); //关闭全局遮罩
        if (r.data.success) {
          this.visiable = false;
          this.$emit("shuaxin");
        }
        this.$message({
          message: r.data.message,
          type: r.data.success ? "success" : "error"
        });
      });
    }
  }
};
</script>