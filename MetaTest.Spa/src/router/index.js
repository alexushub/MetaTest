import Vue from 'vue';
import VueRouter from 'vue-router';
import IpSearch from '../views/IpSearch.vue';

Vue.use(VueRouter);

const routes = [
	{
		path: '/',
		redirect: '/ipsearch',
	},
	{
		path: '/ipsearch',
		name: 'IpSearch',
		component: IpSearch,
	},
	{
		path: '/citysearch',
		name: 'CitySearch',
		component: () => import('../views/CitySearch.vue'),

	},
];

const router = new VueRouter({
	mode: 'history',
	base: process.env.BASE_URL,
	routes,
});

export default router;
