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
