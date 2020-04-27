<template>
  <el-dialog :title="title" :visible.sync="visiable" width="500px" :close-on-click-modal="false">
    <el-form :model="form" label-width="90px">
      <el-form-item label="骑手编号">
        <el-input v-model="form.id" disabled></el-input>
      </el-form-item>
      <el-form-item label="骑手姓名">
        <el-input v-model="form.nameofrider" placeholder="请输入骑手姓名"></el-input>
      </el-form-item>
      <el-form-item label="出生日期">
        <el-input v-model="form.dateofbirth" placeholder="请输入出生日期"></el-input>
      </el-form-item>
      <el-form-item label="入职日期">
        <el-input v-model="form.dateofentry" placeholder="请输入入职日期"></el-input>
      </el-form-item>
      <el-form-item label="骑手地址">
        <el-input v-model="form.rideraddress" placeholder="请输入骑手地址"></el-input>
      </el-form-item>
      <el-form-item label="联系电话">
        <el-input v-model="form.ridercontactnumber" placeholder="请输入骑手联系电话"></el-input>
      </el-form-item>
      <el-form-item label="骑手照片" prop="Src">
        <input
          type="file"
          accept="image/*"
          id="aa"
          @change="fileChange"
          style="width:100%;height:40px;position:absolute;z-index:1;opacity:0.3;"
        />
        <!-- 假的，只用于显示当前选择的文件，或者当前的图片路径 -->
        <el-input v-model="form.Src" placeholder="请选择用户头像" readonly></el-input>
      </el-form-item>
      <el-form-item label="身份证号码">
        <el-input v-model="form.rideridnumber" placeholder="请输入骑手身份证号码"></el-input>
      </el-form-item>
      <el-form-item label="骑手收入">
        <el-input v-model="form.riderincome" placeholder="请输入骑手收入"></el-input>
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
        nameofrider: "",
        dateofbirth: "",
        dateofentry: "",
        rideraddress: "",
        ridercontactnumber: "",
        rideridnumber: "",
        riderincome: "",
        Src: ""
      }
    };
  },
  methods: {
    //文件选择框发生修改的时候触发
    fileChange(e) {
      //判断选择的文件列表中的第0项是否有值
      if (e.target.files[0]) {
        this.form.Src = e.target.files[0].name;
      } else {
        this.form.Src = "";
      }
    },
    opendialog() {
      this.title="添加骑手数据"
      this.form = {
        id: 0,
        nameofrider: "",
        dateofbirth: "",
        dateofentry: "",
        rideraddress: "",
        ridercontactnumber: "",
        riderIdnumber: "",
        riderincome: "",
        Src: ""
      };
      this.visiable = true;
    },
    openeditdialog(data) {
      this.title="修改骑手数据"
      console.log(data);
      this.form = data;
      this.visiable = true;
      this.$nextTick(() => {
        document.getElementById("aa").value = ""; 
      });
    },
    ok() {
      //开启全局遮罩
      this.$loading({ text: "正在上传文件" });
      var url = "";
      if (this.form.id == 0) {
        url = "/rng/Ridingawatch/Add";
      } else {
        url = "/rng/Ridingawatch/Reset";
      }
      //因为要传文件，所以必须用FormData去构建要传递的数据
      var formData = new FormData();
      formData.append("Id", this.form.id);
      formData.append("Nameofrider", this.form.nameofrider);
      formData.append("Dateofbirth", this.form.dateofbirth);
      formData.append("Dateofentry", this.form.dateofentry);
      formData.append("Rideraddress", this.form.rideraddress);
      formData.append("Ridercontactnumber", this.form.ridercontactnumber);
      formData.append("Photosofriders", document.getElementById("aa").files[0]);
      formData.append("RiderIDnumber", this.form.rideridnumber);
      formData.append("Riderincome", this.form.riderincome);

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