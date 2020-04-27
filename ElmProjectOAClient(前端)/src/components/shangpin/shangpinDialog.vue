<template>
  <el-dialog :title="title" :visible.sync="visiable" width="500px" :close-on-click-modal="false">
    <el-form :model="form" label-width="90px">
      <el-form-item label="商品编号">
        <el-input v-model="form.id" disabled></el-input>
      </el-form-item>
      <el-form-item label="商家编号">
        <el-input v-model="form.merchantid" placeholder="请输入商家编号"></el-input>
      </el-form-item>
      <el-form-item label="类别编号">
        <el-input v-model="form.categoryid" placeholder="请输入类别编号"></el-input>
      </el-form-item>
      <el-form-item label="商品名称">
        <el-input v-model="form.tradename" placeholder="请输入商品名称"></el-input>
      </el-form-item>
      <el-form-item label="商品图片" prop="Src">
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
      <el-form-item label="商品描述">
        <el-input v-model="form.commoditydescription" placeholder="请输入商品描述"></el-input>
      </el-form-item>
      <el-form-item label="商品单价">
        <el-input v-model="form.itempricing" placeholder="请输入商品单价"></el-input>
      </el-form-item>
      <el-form-item label="商品折扣">
        <el-input v-model="form.merchandisediscount" placeholder="请输入商品折扣"></el-input>
      </el-form-item>
      <el-form-item label="商品库存">
        <el-input v-model="form.commodityinventory" placeholder="请输入商品库存"></el-input>
      </el-form-item>
      <el-form-item label="商品订购量">
        <el-input v-model="form.orderquantity" placeholder="请输入商品订购量"></el-input>
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
        merchantid: "",
        categoryid: "",
        tradename: "",
        commoditydescription: "",
        itempricing: "",
        merchandisediscount: "",
        commodityinventory: "",
        orderquantity: "",
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
      this.title="添加商品数据"
      this.form = {
        id: 0,
        merchantid: "",
        categoryid: "",
        tradename: "",
        commoditydescription: "",
        itempricing: "",
        merchandisediscount: "",
        commodityinventory: "",
        orderquantity: "",
        Src: ""
      };
      this.visiable = true;
    },
    openeditdialog(data) {
      this.title="修改商品数据"
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
        url = "/rng/Commoditylist/Add";
      } else {
        url = "/rng/Commoditylist/Reset";
      }
      //因为要传文件，所以必须用FormData去构建要传递的数据
      var formData = new FormData();
      formData.append("Id", this.form.id);
      formData.append("MerchantId", this.form.merchantid);
      formData.append("categoryId", this.form.categoryid);
      formData.append("Tradename", this.form.tradename);
      formData.append("Commoditypictures", document.getElementById("aa").files[0]);
      formData.append("CommodityDescription", this.form.commoditydescription);
      formData.append("itempricing", this.form.itempricing);
      formData.append("Merchandisediscount", this.form.merchandisediscount);
      formData.append("Commodityinventory", this.form.commodityinventory);
      formData.append("Orderquantity", this.form.orderquantity);

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