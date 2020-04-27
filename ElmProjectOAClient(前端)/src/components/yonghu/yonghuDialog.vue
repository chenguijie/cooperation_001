<template>
  <el-dialog :title="title" :visible.sync="visiable" width="400px" :close-on-click-modal="false">
    <el-form :model="form" label-width="80px">
      <el-form-item label="Id">
        <el-input v-model="form.id" disabled></el-input>
      </el-form-item>
      <el-form-item label="账号">
        <el-input v-model="form.accountnumber" placeholder="请输入账号"></el-input>
      </el-form-item>
      <el-form-item label="密码">
        <el-input v-model="form.password" placeholder="请输入密码"></el-input>
      </el-form-item>
      <el-form-item label="用户名">
        <el-input v-model="form.username" placeholder="请输入用户名"></el-input>
      </el-form-item>
      <el-form-item label="图片" prop="Src">
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
    </el-form>

    <template v-slot:footer>
      <el-button @click="visiable= false">取 消</el-button>
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
        accountnumber: "",
        password: "",
        username: "",
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
      this.title="添加用户数据"
      this.form = {
        id: 0,
        accountnumber: "",
        password: "",
        username: "",
        Src: ""
      };
      this.visiable = true;
    },
    openeditdialog(data) {
      this.title="修改用户数据"
      console.log(data);
      this.form = data;
      this.visiable = true;
    },
    ok() {
      //开启全局遮罩
      this.$loading({ text: "正在上传文件" });
      var url = "";
      if (this.form.id == 0) {
        url = "/rng/UserTable/Add";
      } else {
        url = "/rng/UserTable/Reset";
      }
      //因为要传文件，所以必须用FormData去构建要传递的数据
      var formData = new FormData();
      formData.append("id", this.form.id);
      formData.append("accountnumber", this.form.accountnumber);
      formData.append("password", this.form.password);
      formData.append("username", this.form.username);
      formData.append("userhead", document.getElementById("aa").files[0]);

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