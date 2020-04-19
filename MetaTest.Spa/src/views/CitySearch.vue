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
		text: 'City',
		value: 'city',
	},
	{
		text: 'Organization',
		value: 'organization',
	},
	{
		text: 'Postal',
		value: 'postal',
	},
	{
		text: 'Latitude',
		value: 'latitude',
	},
	{
		text: 'Longitude',
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
