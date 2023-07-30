# Stage 1: Build the Angular Application
FROM node:16 as builder

WORKDIR /app

# Copy package.json and package-lock.json
COPY package*.json ./

# Install dependencies
RUN npm install

# Copy the Angular app files to the container
COPY . .

# Build the Angular app for production
RUN npm run build

# Stage 2: Create the Nginx Web Server Container
FROM nginx:alpine

# Remove default Nginx website
RUN rm -rf /usr/share/nginx/html/*

# Copy the built Angular app from the previous stage to Nginx's web root directory
COPY --from=builder /app/dist/product-management /usr/share/nginx/html

# Expose the Nginx HTTP port
EXPOSE 80

# Start Nginx
CMD ["nginx", "-g", "daemon off;"]
