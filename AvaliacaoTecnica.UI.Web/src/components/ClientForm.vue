<template>
    <div>
        <h2>Adicionar Cliente</h2>
        <form @submit.prevent="addClient">
            <label for="companyName">Nome da Empresa:</label>
            <input v-model="companyName" id="companyName" required />

            <label for="size">Porte da Empresa:</label>
            <select v-model="size" id="size" required>
                <option value=1>Pequena</option>
                <option value=2>M&eacutedia</option>
                <option value=3>Grande</option>
            </select>

            <button type="submit">Adicionar</button>
        </form>

    </div>
</template>

<script>

    export default {
        data() {
            return {
                companyName: '',
                size: 1
            }
        },
        methods: {
            async addClient() {
                try {
                    const response = await fetch('https://localhost:44389/client-management', {
                        method: 'POST',
                        headers: {
                            'Content-Type': 'application/json'
                        },
                        body: JSON.stringify({
                            companyName: this.companyName,
                            size: this.size
                        })
                    });
                    // Limpa os campos após adicionar o cliente

                    this.$router.push('/clients');

                    // Você pode atualizar a lista de clientes aqui se necessário
                } catch (error) {
                    console.error('Erro ao adicionar o cliente:', error);
                }
            }
        }
    }
</script>