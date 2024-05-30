import { defineConfig } from 'vite'
import react from '@vitejs/plugin-react-swc'

// https://vitejs.dev/config/
export default defineConfig({
  plugins: [react()],
  server: {
    port: 6060,
    proxy: {
      "/api":{
        target: "http://127.0.0.1:5028", 
        changeOrigin: true,
        rewrite: (path) => path.replace(/^\/api/, "api/"),
      }
    }
  }
}) 
