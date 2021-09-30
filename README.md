# simple-inter-system-api-example <!-- omit in toc -->

[![Conventional Commits](https://img.shields.io/badge/Conventional%20Commits-1.0.0-yellow.svg)](https://conventionalcommits.org)

[![issue-tracker](https://github.com/el-bastard0/simple-inter-system-api-example/actions/workflows/issue-tracker.yml/badge.svg)](https://github.com/el-bastard0/simple-inter-system-api-example/actions/workflows/issue-tracker.yml)
[![dotnet-semantic-release](https://github.com/el-bastard0/simple-inter-system-api-example/actions/workflows/dotnet-semantic-release.yml/badge.svg)](https://github.com/el-bastard0/simple-inter-system-api-example/actions/workflows/dotnet-semantic-release.yml)

## Content <!-- omit in toc -->

- [1. Prerequisites](#1-prerequisites)
- [2. Swagger (OpenAPI)](#2-swagger-openapi)
- [3. cURL](#3-curl)
  - [3.1. Get all entities](#31-get-all-entities)
  - [3.2. Get entity by id](#32-get-entity-by-id)
  - [3.3. Create entity](#33-create-entity)
  - [3.4. Update entity](#34-update-entity)
  - [3.5. Delete entity](#35-delete-entity)

## 1. Prerequisites

1. Open [api project](src/api/ElBastard0.Api.csproj) in an editor by your choice.
2. Run project

## 2. Swagger (OpenAPI)

Swagger documentation page should automatically open in the browser you configured. If not open [https://localhost:5001/swagger](https://localhost:5001/swagger) in the browser of your choice. All awailable api endpoints can be tested here.

## 3. cURL

Open PowerShell (or any other console with access to cURL)

### 3.1. Get all entities

``` PS
curl -X GET 'https://localhost:5001/api/Default' -H  'accept: application/json'
```

Should return something similar to

``` PS
[
    {
        "id": 1,
        "value": "Example Entity 1"
    },
    {
        "id": 2,
        "value": "Example Entity 2"
    }
]
```

### 3.2. Get entity by id

``` PS
curl -X GET 'https://localhost:5001/api/Default/1' -H  'accept: application/json'
```

Should return

``` PS
{
  "id": 1,
  "value": "Example Entity 1"
}
```

### 3.3. Create entity

``` PS
curl -X POST 'https://localhost:5001/api/Default' `
 -H  'accept: application/json' -H  'Content-Type: application/json' `
 -d '{\"value\":\"Example Entity 3\"}'
```

Should return

``` PS
{
  "id": 3,
  "value": "Example Entity 3"
}
```

### 3.4. Update entity

``` PS
curl -X PUT 'https://localhost:5001/api/Default/3' `
 -H  'accept: application/json' -H  'Content-Type: application/json' `
 -d '{\"id\":\"3\",\"value\":\"Test Entity 3\"}'
```

Should return

``` PS
{
  "id": 3,
  "value": "Test Entity 3"
}
```

### 3.5. Delete entity

``` PS
curl -X DELETE 'https://localhost:5001/api/Default/3' -H  'accept: */*'
```

Should return empty response
