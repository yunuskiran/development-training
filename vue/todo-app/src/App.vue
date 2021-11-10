<template>
  <div class="container">
    <img alt="Vue logo" src="./assets/logo.png" />
    <TodoForm :about="about" />
  </div>
</template>

<script lang="ts">
import { defineComponent, ref } from "vue";
import TodoForm from "./components/TodoForm.vue";

export default defineComponent({
  name: "App",
  components: {
    TodoForm,
  },

  setup() {
    const about = ref({
      title: "Vue 3",
      subTitle: "TypeScript demo",
    });

    return {
      about,
    };
  },
});
</script>

<style>
@import "../node_modules/bootstrap/dist/css/bootstrap.css";
</style>