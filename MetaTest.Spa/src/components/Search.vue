<template>
  <div class="home">
    <h2>{{ header }}</h2>
    <SearchBarComponent @search="search"/>
	<ResultTableComponent :data="searchResult" :columns-info="columnsInfo" />
  </div>
</template>

<script>

import SearchBarComponent from '@/components/SearchBarComponent.vue';
import ResultTableComponent from '@/components/ResultTableComponent.vue';
import httpService from '@/services/httpService';

export default {
	name: 'Search',
	components: {
		SearchBarComponent,
		ResultTableComponent,
	},
	props: {
		header: String,
		baseUrl: String,
		columnsInfo: Array,
	},
	data() {
		return {
			searchResult: null,
		};
	},
	methods: {
		async search(str) {
			this.searchResult = null;

			const url = this.baseUrl + str;
			const result = await httpService.get(url);
			if (result.data) {
				if (Array.isArray(result.data)) {
					this.searchResult = result.data;
				} else {
					this.searchResult = [result.data];
				}
			} else {
				this.searchResult = [];
			}
		},
	},
};
</script>
