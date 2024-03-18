<template>
    <div>
        <h2>Lista de Clientes</h2>
        <ul>
            <li v-for="client in clients" :key="client.id">
                {{ client.companyName }}   -   {{ client.size }}
                <button @click="removeClient(client.id)">Remover</button>
                <button @click="EditClient(client.id)">Editar</button>

            </li>
        </ul>
        <router-link to="/clients/new">Adicionar Cliente</router-link>
    </div>
</template>


<script>
    export default {
        data() {
            return {
                clients: []
            }
        },
        mounted() {
            this.fetchClients();
        },
        methods: {
            async fetchClients() {
                try {
                    const response = await fetch('https://localhost:44389/client-management');
                    this.clients = await response.json();
                } catch (error) {
                    console.error('Erro ao carregar os clientes:', error);
                }
            },
            async removeClient(clientId) {
                try {
                    await fetch(`https://localhost:44389/client-management/${clientId}`, {
                        method: 'DELETE'
                    });
                    // Atualiza a lista de clientes após a remoção
                    this.clients = this.clients.filter(client => client.id !== clientId);
                } catch (error) {
                    console.error('Erro ao remover o cliente:', error);
                }
            },
            async EditClient(clientId) {
                
                try {
                   this.$router.push('/clients/editar/'+clientId);

                } catch (error) {
                    console.error('Erro ao atualizar o cliente:', error);
                }
            }
        }
    }
</script>