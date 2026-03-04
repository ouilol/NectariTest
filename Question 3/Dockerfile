ARG BUILD_FROM=mcr.microsoft.com/mssql/server:2019-latest
FROM ${BUILD_FROM} AS builder

USER root

# Accept terms and set password
ENV ACCEPT_EULA=Y
ENV SA_PASSWORD=YourStrong@Passw0rd!

# Create the directory where restore_db search it
RUN mkdir -p /var/opt/mssql/docker/

WORKDIR /app
COPY . .

# Copy data to restore to right directory
RUN cp data.sql /var/opt/mssql/docker/

# Change permission on two script so they are executable
RUN chmod +x restore_db.sh entrypoint.sh

# install sql tools with root user for restore_db.sh 
USER root
RUN apt-get update && \
    apt-get install -y curl gnupg2 && \
    curl https://packages.microsoft.com/keys/microsoft.asc | apt-key add - && \
    curl https://packages.microsoft.com/config/ubuntu/20.04/prod.list > /etc/apt/sources.list.d/mssql-release.list && \
    apt-get update && \
    ACCEPT_EULA=Y apt-get install -y mssql-tools unixodbc-dev && \
    echo 'export PATH="$PATH:/opt/mssql-tools/bin"' >> ~/.bashrc
USER mssql

# STart sql , restore database and kill it
RUN /opt/mssql/bin/sqlservr & \
    ./restore_db.sh && \
    pkill sqlserv

# ---------------------------------------------------------
FROM ${BUILD_FROM}
ENV ACCEPT_EULA=Y

HEALTHCHECK --interval=10s --timeout=3s \
  CMD nc -z localhost 1433 || exit 1

# Copy the build data with restored data.sql in the final image and copy the entrypoint script
COPY --from=builder /var/opt/mssql/data /var/opt/mssql/data
COPY --from=builder /app/entrypoint.sh /usr/local/bin/entrypoint.sh

USER mssql
ENTRYPOINT ["entrypoint.sh"]