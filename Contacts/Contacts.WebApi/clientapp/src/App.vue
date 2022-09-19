<template>
  <div id="app">
    <ContactTable />
  </div>
</template>

<script>
import ContactTable from "./components/contact-table/ContactTable";

export default {
  name: 'app',
  components: {
    ContactTable
  }
}
</script>

<style>
#app {
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  color: #2c3e50;
  padding: 50px;
}
</style>
