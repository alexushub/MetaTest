<template>
  <div class="search-bar">
    <input v-model="searchStr" @keyup.enter="search" type="text">
    <button @click="search">Search</button>
  </div>
</template>

<script>
export default {
	name: 'SearchBar',
	props: {
	},
	data() {
		return {
			searchStr: null,
		};
	},
	methods: {
		search() {
			this.$emit('search', this.searchStr);
		},
	},
};
</script>

<style scoped lang="scss">
	.search-bar {
		margin-top: 15px;
	}
	input {
		border: 1px solid grey;
		margin-right: 5px;
	}
	button {
		border: 1px solid black;
	}
</style>
