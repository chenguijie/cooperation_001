<template>
  <div class="ddd">
    <el-dialog
      :visible.sync="visiable"
      width="30%"
      :close-on-click-modal="false"
      :show-close="false"
      :modal-append-to-body="false"
    >
      <div slot="title">
        <i class="el-icon-position"></i> 登录
      </div>
      <div>
        <p>
          <el-input v-model="loginame" clearable placeholder="请输入用户名">
            <div slot="prepend" style="width:60px;">用户名</div>
          </el-input>
        </p>
        <p>
          <el-input type="password" clearable show-password v-model="password" placeholder="请输入密码">
            <div slot="prepend" style="width:60px;">密码</div>
          </el-input>
        </p>
      </div>
      <div slot="footer">
        <el-button type="primary" @click="login">登录</el-button>
      </div>
    </el-dialog>
  </div>
</template>
<script>
import axios from "axios";
export default {
  data() {
    return {
      visiable: true,
      loginame: "",
      password: ""
    };
  },
  methods: {
    login() {
      axios.post("/rng/Login/Verification", {
            Account:this.loginame,
            Password:this.password
          }
        )
        .then(res => {
          if(res.data.success==true){
            this.$router.push("/home");
          }
          else{
            alert(res.data.message);
          }
        });
    }
  }
};
</script>

<style >
.ddd {
  background-repeat: no-repeat;
  background-size: cover;
  background-image: url(../assets/1.png);

  position: fixed;
  top: 0;
  bottom: 0;
  left: 0;
  right: 0;
  z-index: -1;
}
</style>




