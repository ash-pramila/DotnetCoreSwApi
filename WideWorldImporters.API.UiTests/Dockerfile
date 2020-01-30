FROM aspchrome
WORKDIR /data
COPY . ./
RUN mkdir -p Reports
RUN dotnet restore 
CMD dotnet test --logger 'trx;LogFileName=TestResults.trx' --results-directory /data/Reports/UiTests
