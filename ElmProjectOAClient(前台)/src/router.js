import Vue from 'vue'
import Router from 'vue-router'
import Cookies from 'vue-cookies'
Vue.use(Cookies)
Vue.use(Router);

var router=new Router({
    mode:'history',
    routes:[
        {
            name:'login',
            path:'/login',
            component:()=> import('./components/login.vue')
        },
        {
            name:"home",
            path:'/home',
            component:()=> import('./components/home.vue'),
            children:[
                {
                    path:'/home',
                    component:()=>import('./components/index.vue'),
                },
                {
                    path:"/home/yonghu",
                    component:()=>import('./components/yonghu.vue'),
                },
                {
                    path:"/home/dingdan",
                    component:()=>import('./components/dingdan.vue'),
                },
                {
                    path:"/home/qishou",
                    component:()=>import('./components/qishou.vue')
                },
                {
                    path:"/home/shangpin",
                    component:()=>import('./components/shangpin.vue')
                },
                {
                    path:"/home/shouhuodizhi",
                    component:()=>import('./components/shouhuodizhi.vue')
                },
                {
                    path:"/home/dingdanmingxi",
                    component:()=>import('./components/dingdanmingxi.vue')
                },
                {
                    path:"/home/shangjia",
                    component:()=>import('./components/shangjia.vue')
                },
                {
                    path:"/home/leibie",
                    component:()=>import('./components/leibie.vue')
                },
            ]
        },{
            path:"/*",
            redirect:'/login'
        }
    ]
});

// router.beforeEach((to, from, next) => {
//     var path=to.path;
//     if(path=='/login'){
//         next();
//     }else{
//         var user = Vue.$cookies.get('node_auth')
//         if (user) {
//           next();
//         } else {
//           //优化一下，要访问的路径添加到query当中
//           next({path:'/login',query:{returnUrl:to.fullPath}})
//         }
//     }
// })

export default router;