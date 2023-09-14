<template>
    <div class="post">
        <div v-if="loading" class="loading">
            Loading... Please refresh once the ASP.NET backend has started. See <a href="https://aka.ms/jspsintegrationvue">https://aka.ms/jspsintegrationvue</a> for more details.
        </div>

        <div v-if="grid" class="content">
            <table>
                <tbody>
                    <tr v-for="row in hashedGrid" :key="row.key">
                        <td v-for="item in row" :key="item.key">{{ item.type }}</td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
</template>

<script lang="js">
    import { defineComponent } from 'vue';
    import { sha1 } from 'object-hash';

    export default defineComponent({
        data() {
            return {
                loading: false,
                grid: null
            };
        },
        computed: {
            hashedGrid() {
                return this.grid.items.map(row => ({ ...row.map(item => ({ ...item, key: sha1(item)})), key: sha1(row)}));
            },
        },
        created() {
            // fetch the data when the view is created and the data is
            // already being observed
            this.fetchData();
        },
        watch: {
            // call again the method if the route changes
            '$route': 'fetchData'
        },
        methods: {
            fetchData() {
                this.grid = null;
                this.loading = true;

                fetch('Grid')
                    .then(r => r.json())
                    .then(json => {
                        this.grid = json;
                        this.loading = false;
                        return;
                    });
            }
        },
    });
</script>