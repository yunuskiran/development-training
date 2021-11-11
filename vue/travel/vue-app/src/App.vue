<template>
  <v-app>
    <NavigationBar />
    <v-main>
      <router-view />
    </v-main>
  </v-app>
</template>

<script>
import NavigationBar from "@/components/NavigationBar";
import { mapGetters } from "vuex";

export default {
  name: "App",
  components: {
    NavigationBar,
  },
  computed: {
    ...mapGetters("authModule", {
      isAuthenticated: "isAuthenticated",
      email: "email",
    }),
  },
};
</script>