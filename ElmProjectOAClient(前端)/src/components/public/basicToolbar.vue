<template>
  <div class="mine-toolbar">
    <el-button
      type="success"
      style="vertical-align:middle;margin-right:20px;"
      icon="el-icon-plus"
      round
      plain
      @click="$emit('add')"
    >添加</el-button>

    <el-input
      v-model="keyword"
      placeholder="请输入查询关键字"
      @keydown.13.native="$emit('search',keyword)"
      style="width:350px;vertical-align:middle;margin-right:20px"
    >
      <template v-slot:prepend>
        <span>搜索</span>
      </template>
      <template v-slot:append>
        <el-button type="primary" icon="el-icon-search" @click="$emit('search',keyword)"></el-button>
      </template>
    </el-input>

    <el-button
      style="vertical-align:middle"
      type="primary"
      round
      plain
      icon="el-icon-refresh"
      @click="$emit('refresh')"
    >刷新</el-button>
  </div>
</template>
<script>
export default {
  data() {
    return {
      keyword: ""
    };
  }
};
</script>

<style lang="less">
.mine-toolbar {
  padding: 5px 5px 5px 5px;
  background: #fcfcfc;
  margin: -5px -5px 0px -5px;
  border-bottom: 1px solid #eee;

  // 为搜索框添加左右圆角
  .el-input-group__prepend {
    border-radius: 20px 0 0 20px !important;
  }
  .el-input-group__append {
    border-radius: 0 20px 20px 0 !important;
  }
}
</style>