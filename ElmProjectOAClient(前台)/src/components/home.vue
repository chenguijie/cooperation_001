<template>
  <div>
    <div id="layout-left">
      <el-menu router :default-active="defaultActive" background-color="skyblue" text-color="black">
        <el-menu-item index="/home">
          <i class="el-icon-s-home"></i>
          <span>首页</span>
        </el-menu-item>
        <el-menu-item index="/home/yonghu">
          <i class="el-icon-s-operation"></i>
          <span>用户管理</span>
        </el-menu-item>
        <el-menu-item index="/home/shouhuodizhi">
          <i class="el-icon-s-operation"></i>
          <span>用户地址管理</span>
        </el-menu-item>
        <el-menu-item index="/home/dingdan">
          <i class="el-icon-s-operation"></i>
          <span>订单管理</span>
        </el-menu-item>
        <el-menu-item index="/home/dingdanmingxi">
          <i class="el-icon-s-operation"></i>
          <span>订单明细</span>
        </el-menu-item>
        <el-menu-item index="/home/qishou">
          <i class="el-icon-s-operation"></i>
          <span>骑手管理</span>
        </el-menu-item>
        <el-menu-item index="/home/shangpin">
          <i class="el-icon-s-operation"></i>
          <span>商品管理</span>
        </el-menu-item>
        <el-menu-item index="/home/leibie">
          <i class="el-icon-s-operation"></i>
          <span>商品类别管理</span>
        </el-menu-item>
        <el-menu-item index="/home/shangjia">
          <i class="el-icon-s-operation"></i>
          <span>商家管理</span>
        </el-menu-item>
      </el-menu>
    </div>

    <div id="layout-right">
      <!-- 右侧头部 -->
      <div id="layout-head">
        <el-breadcrumb>
          <el-breadcrumb-item :to="{ path: '/' }">首页</el-breadcrumb-item>
          <el-breadcrumb-item>{{pageName}}</el-breadcrumb-item>
        </el-breadcrumb>
        <div class="headimg">
          <el-dropdown @command="command">
            <el-avatar icon="el-icon-user-solid"></el-avatar>
            <el-dropdown-menu slot="dropdown">
              <el-dropdown-item icon="el-icon-lock" command="a">修改密码</el-dropdown-item>

              <el-dropdown-item icon="el-icon-switch-button" command="b" divided>退出登录</el-dropdown-item>
            </el-dropdown-menu>
          </el-dropdown>
        </div>
      </div>
      <!-- 右侧中部，用来显示管理功能内容的 -->
      <div id="layout-main">
        <router-view></router-view>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      defaultActive: this.$route.path
    };
  },
  computed: {
    pageName() {
      var dic = {
        "/home": "",
        "/home/yonghu":"用户管理界面",
        "/home/dingdan":"订单管理界面",
        "/home/qishou":"骑手管理界面",
        "/home/shangpin":"商品管理界面",
        "/home/shouhuodizhi":"用户地址管理界面",
        "/home/dingdanmingxi":"订单明细",
        "/home/shangjia":"商家管理",
        "/home/leibie":"类别管理"
      };
      return dic[this.$route.path];
    }
  },
  methods: {
    command(e) {
      console.log(e);
       switch(e){
                case "a":
                    break;
                case "b":
                    this.$cookies.set('node_auth','','0s')
                    this.$router.push('/login')
                    break;
            }
    }
  }
};
</script>

<style lang="less" scoped>
#layout-left {
  position: fixed;
  height: 100%;
  border-right: 1px solid #ccc;
  width: 180px;
  background: skyblue;
  overflow-x: hidden;
}
#layout-right {
  margin-left: 181px;
  #layout-head {
    height: 50px;
    overflow: hidden;
    box-shadow: 0px 0px 5px rgba(0, 0, 0, 0.342);
    border-bottom: 1px solid #ccc;
  }
  #layout-main {
    padding: 5px;
  }
}
.el-breadcrumb {
  float: left;
  margin: 16px 10px;
  font-size: 14px;
}
.headimg {
  float: right;
  padding: 5px 15px;
}
</style>
<style>
.el-breadcrumb__inner.is-link {
  font-weight: normal;
}
.el-menu {
  border-right: none;
}
</style>