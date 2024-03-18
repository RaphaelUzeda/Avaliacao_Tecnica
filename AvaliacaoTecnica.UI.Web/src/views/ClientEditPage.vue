<!-- EditarCliente.vue -->
<template>
    <div>
        <h2>Editar Cliente</h2>
        <form @submit.prevent="editarCliente">
            <label for="companyName">Nome da Empresa:</label>
            <input v-model="cliente.companyName" id="companyName" required />

            <label for="size">Porte da Empresa:</label>
            <select v-model="cliente.size" id="size" required>
                <option value=1>Pequena</option>
                <option value=2>M&eacutedia</option>
                <option value=3>Grande</option>
            </select>

            <button type="submit">Salvar</button>
        </form>
    </div>
</template>

<script>
    export default {
        data() {
            return {
                cliente: {
                    companyName: '',
                    size: 1
                }
            };
        },
        mounted() {
            // Aqui você fará uma requisição GET para a sua API ASP.NET para obter os dados do cliente a ser editado
            this.carregarCliente();
        },
        methods: {
            async carregarCliente() {
                try {
                    const clienteId = this.$route.params.id;
                    const response = await fetch(`https://localhost:44389/client-management/${clienteId}`);
                    this.cliente = await response.json();
                    console.log(this.cliente)
                } catch (error) {
                    console.error('Erro ao carregar cliente:', error);
                }
            },
            async editarCliente() {
                try {
                    const clienteId = this.$route.params.id;
                    this.cliente.size = parseInt(this.cliente.size)
                    let cliente = this.cliente;
                    await fetch('https://localhost:44389/client-management', {
                        method: 'PUT',
                        headers: {
                            'Content-Type': 'application/json'
                        },
                        body: JSON.stringify(cliente)
                    });
                    // Redirecionar para a lista de clientes após a edição
                    this.$router.push('/clients');
                } catch (error) {
                    console.error('Erro ao editar cliente:', error);
                }
            }
        }
    };
</script>
