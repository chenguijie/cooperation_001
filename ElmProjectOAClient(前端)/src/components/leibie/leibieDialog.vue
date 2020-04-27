<template>
  <el-dialog :title="title" :visible.sync="visiable" width="500px" :close-on-click-modal="false">
    <el-form :model="form" label-width="90px">
      <el-form-item label="类别编号">
        <el-input v-model="form.id" disabled></el-input>
      </el-form-item>
      <el-form-item label="类别名称">
        <el-input v-model="form.categoryname" placeholder="请输入类别名称"></el-input>
      </el-form-item>
      <el-form-item label="类别描述">
        <el-input v-model="form.classdescription" placeholder="请输入类别描述"></el-input>
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
        categoryname:'',
        classdescription:''
      }
    };
  },
  methods: {
    opendialog() {
      this.title="添加类别数据"
      this.form = {
        id: 0,
        categoryname:'',
        classdescription:''
      };
      this.visiable = true;
    },
    openeditdialog(data) {
      this.title="修改类别数据"
      console.log(data);
      this.form = data;
      this.visiable = true;
    },
    ok() {
      //开启全局遮罩
      this.$loading({ text: "正在上传文件" });
      var url = "";
      if (this.form.id == 0) {
        url = "/rng/Classtable/Add";
      } else {
        url = "/rng/Classtable/Reset";
      }
      //因为要传文件，所以必须用FormData去构建要传递的数据
      var formData = new FormData();
      formData.append("Id", this.form.id);
      formData.append("Categoryname", this.form.categoryname);
      formData.append("Classdescription", this.form.classdescription);

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