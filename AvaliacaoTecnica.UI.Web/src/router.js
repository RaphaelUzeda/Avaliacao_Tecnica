import { createRouter, createWebHistory } from 'vue-router'
import ClientListPage from './views/ClientListPage.vue'
import ClientFormPage from './views/ClientFormPage.vue'
import ClientEditPage from './views/ClientEditPage.vue'

const routes = [
    { path: '/', component: ClientListPage },
    { path: '/clients', component: ClientListPage },
    { path: '/clients/new', component: ClientFormPage },
    { path: '/clients/editar/:id', component: ClientEditPage, props: true }
]

const router = createRouter({
    history: createWebHistory(),
    routes
})

export default router