import AuthLayout from "@/views/Layouts/AuthLayout.vue";
import DashboardLayout from "@/views/Layouts/DashboardLayout.vue";

import NotFound from "@/views/Pages/Errors/NotFound.vue";

const Dashboard = () =>
  import(
    /* webpackChunkName: "page" */ "@/views/Pages/Dashboard/Dashboard.vue"
  );

const Home = () =>
  import(/* webpackChunkName: "pages" */ "@/views/Pages/Home.vue");
const Login = () =>
  import(/* webpackChunkName: "pages" */ "@/views/Pages/Auth/Login.vue");
const Register = () =>
  import(/* webpackChunkName: "pages" */ "@/views/Pages/Auth/Register.vue");
const UserProfile = () =>
  import(
    /* webpackChunkName: "page" */ "@/views/Pages/Dashboard/UserProfile.vue"
  );

const dashboardPages = {
  path: "/",
  component: DashboardLayout,
  redirect: "/dashboard",
  name: "Dashboard Layout",
  meta: {
    requiresAuth: false
  },
  children: [
    {
      path: "dashboard",
      name: "Dashboard",
      component: Dashboard,
      meta: {
        title: "Dashboard - Teach"
      }
    },
    {
      path: "/userProfile",
      name: "UserProfile",
      component: UserProfile,
      meta: {
        title: "Perfil - Teach",
        redirectToDashboardIfConnected: true
      }
    }
  ]
};

// Authentication
const authPages = {
  path: "/",
  component: AuthLayout,
  name: "Authentication",
  children: [
    {
      path: "/Home",
      name: "Home",
      component: Home,
      meta: {
        noBodyBackground: true,
        title: "Teach"
      }
    },
    {
      path: "/login",
      name: "Login",
      component: Login,
      meta: {
        title: "Entrar - Teach",
        redirectToDashboardIfConnected: true
      }
    },
    {
      path: "/register",
      name: "Register",
      component: Register,
      meta: {
        title: "Registrar - Teach",
        redirectToDashboardIfConnected: true
      }
    },

    {
      path: "/posts",
      name: "posts",
      component: UserProfile,
      meta: {
        title: "Mensagens",
        redirectToDashboardIfConnected: true
      }
    },
    { path: "*", component: NotFound }
  ]
};

const routes = [
  {
    path: "/",
    redirect: "/Home"
  },
  dashboardPages,
  authPages
];

export default routes;
