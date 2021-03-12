# AnotaCar
Progeto integrador UNOESC - Sistema para gestão de custos de veículo pessoal.

## Lista de funcionalidades 
_(Atualizar o redame a cada funcionalidade implementada)_


- [x] Implementar o crud básico de usuários e login de usuário.
   - [ ] Redirecionar direto pro login sem confirmação de e-mail
   - [ ] Validar para o usuário não conseguir acessar telas sem estar logado
- [x] Implementar o cadastro de veículo e tabelas de dependência
   - [ ] Adicionar dados padrão ao inicializar.
- [ ] Implementar o cadastro de abastecimentos
- [ ] Implementar o cadastro de serviços prestados (Lavagem, pedágio, limpeza de ar condicionado, Balanceamento, geometria ... permitir cadastrar outros)
- [ ] Implementar o cadastro de manutenções, preventivas e corretivas (Revisão, troca de óleo, filtros, Troca de Pneu ... Permitir cadastrar outros) 

## Implementar a extração de relatórios em formato de gráficos:

* Geral
    * Trazer um dashboard básico de todos os totalizadores (KM, R$, custo por KM, custo por mês, custo por dia, dividir tudo por veículo se houver)
* Abastecimento
  * Total de KM e R$ gasto por período
  * Total por tipo de combustível
  * Total por veículo se houver mais de um para este usuário
* Serviços
  * Valores totais por veículo, por dia, por mes, e do período.
* Manutenções
  * Valores totais por veículo, por dia, por mes, e do período.

## Guia de configuração do ambiente:

* Instale o visual Studio neste [link](https://visualstudio.microsoft.com/pt-br/vs/community/).
* Instale o SDK do .net 6 neste [link](https://dotnet.microsoft.com/download/dotnet/thank-you/sdk-6.0.100-preview.1-windows-x64-installer)
* Instale o PostgreSQL [aqui](https://www.enterprisedb.com/downloads/postgres-postgresql-downloads). Eu estou usando a versão 12, mas possvelmente o Entity seja compatível com o 13 
* Configure sua senha em PostgreSQLConnectionString do arquivo appsettings.Json
