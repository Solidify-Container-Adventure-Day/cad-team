FROM node:lts-alpine AS deps

WORKDIR /opt/app
COPY package.json package-lock.json ./
RUN npm install --frozen-lockfile

FROM node:lts-alpine AS builder

ENV NODE_ENV=production
WORKDIR /opt/app
COPY . .
COPY --from=deps /opt/app/node_modules ./node_modules
RUN npm run build

FROM node:lts-alpine AS runner

ENV NODE_ENV=production
WORKDIR /opt/app
EXPOSE 3000
ENV API_URL=https://cad-mining-backend--5iocjb2.niceplant-9cf5e74e.northeurope.azurecontainerapps.io
COPY --from=builder /opt/app/next.config.js ./
COPY --from=builder /opt/app/public ./public
COPY --from=builder /opt/app/.next ./.next
COPY --from=builder /opt/app/node_modules ./node_modules
CMD ["node_modules/.bin/next", "start"]