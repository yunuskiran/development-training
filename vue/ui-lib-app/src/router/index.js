import Vue from "vue";
import VueRouter from "vue-router";
import Home from "@/views/Main/Home";
import TourList from "@/views/AdminDashboard/TourList";
import TourPackages from "@/views/AdminDashboard/TourPackages";

Vue.use(VueRouter);

const routes = [
  {
    path: "/",
    name: "Home",
    component: Home
  },
  {
    path: "/admin-dashboard",
    component: () => import("@/views/AdminDashboard"),
    children: [
      {
        path: "",
        component: () => import("@/views/AdminDashboard/DefaultContent"),
      },
      {
        path: "weather-forecast",
        component: () => import("@/views/AdminDashboard/WeatherForecast"),
      },
      {
        path: "tour-lists",
        component: TourList,
      },
      {
        path: "tour-packages",
        component: TourPackages,
      }
    ],
  },
  {
    path: "*",
    redirect: "/",
  },
];

const router = new VueRouter({
  mode: "history",
  base: process.env.BASE_URL,
  routes,
});

export default router;