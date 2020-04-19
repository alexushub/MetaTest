<template>
  <div class="home">
		<Search :header="headerStr" :base-url="request" :columns-info="columnsInfo" />
  </div>
</template>

<script>

import Search from '@/components/Search.vue';
import constants from '@/constants';

const headerStr = 'Search by City';
const request = `${constants.server_url}city/locations?city=`;

const columnsInfo = [
	{
		text: 'organization',
		value: 'organization',
	},
	{
		text: 'postal',
		value: 'postal',
	},
	{
		text: 'latitude',
		value: 'latitude',
	},
	{
		text: 'longitude',
		value: 'longitude',
	},

];

export default {
	name: 'CitySearch',
	components: {
		Search,
	},
	data() {
		return {
			searchResult: null,
			searchString: null,
			headerStr,
			request,
			columnsInfo,
		};
	},
	methods: {
	},
};
</script>
