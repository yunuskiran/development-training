import state from './state';
import getters from './getter';
import mutations from './mutation';
import * as actions from './action';

export default {
    namespaced: true,
    getters,
    mutations,
    actions,
    state
};
