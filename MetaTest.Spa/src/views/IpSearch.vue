<template>
  <div class="home">
		<Search :header="headerStr" :base-url="request" :columns-info="columnsInfo" />
  </div>
</template>

<script>

import Search from '@/components/Search.vue';
import constants from '@/constants';

const headerStr = 'Search by IP';
const request = `${constants.server_url}ip/location?ip=`;

const columnsInfo = [
	{
		text: 'Country',
		value: 'country',
	},
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
	name: 'IpSearch',
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
