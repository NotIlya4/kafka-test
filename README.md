# Kafka Test
In this project i want to simulate typical microservice behavior when one service responsible for creating entities and second service needs part of that data. And since its a microservices we don't want to directly speak with another microservice. Better solution would be to listen to messages that microservice emits and replicate needed data.

This repository consist of 2 services. Product service can create new products. Product entity contains id, name, price, brand. Order service want to have access to product id and price. So instead of directly asking product service for a price of specific product order service will listen to kafka topic that will be used by product service that emits new messages when new product created.

Currently WIP. 