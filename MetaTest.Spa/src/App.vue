<template>
  <div id="app" class="container">
    <div id="nav" class="navigation">
      <router-link to="/ipsearch">IP search</router-link>
      <router-link to="/citysearch">City search</router-link>
    </div>
	<div class="view">
		<router-view/>
	</div>

  </div>
</template>

<style lang="scss">
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}

#nav {
  padding: 30px;

  a {
    font-weight: bold;
    color: #2c3e50;

    &.router-link-exact-active {
      color: #42b983;
    }
  }
}

.container {
	display: flex;
	justify-content: center;
	align-items: flex-start;
  }

  .navigation {
		display: flex;
		flex-direction: column;

		width: 200px;
		//flex-grow: 1;
  }

  .view {
		width: 600px;
		//flex-grow: 2;
  }
</style>
