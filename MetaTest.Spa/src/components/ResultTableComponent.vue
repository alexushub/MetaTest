<template>
	<div v-if="data" class="hello">
		<v-data-table
			:headers="columnsInfo"
			:items="data"
			:items-per-page="50"
			class="elevation-1">
		</v-data-table>
	</div>
</template>

<script>

export default {
	name: 'ResultTable',
	components: {
		// DataTables,
	},
	props: {
		data: Array,
		columnsInfo: Array,

	},
	data() {
		return {
		};
	},
	methods: {
	},
};
</script>

<style scoped lang="scss">

</style>
