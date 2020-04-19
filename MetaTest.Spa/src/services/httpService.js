import axios from 'axios';

export default class httpService {
	static async get(url) {
		const result = await axios.get(url);
		return result;
	}
}
