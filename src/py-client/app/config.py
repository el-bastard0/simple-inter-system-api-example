from pydantic import BaseSettings, Field, AnyHttpUrl


class Settings(BaseSettings):
    BACKEND_URL: AnyHttpUrl = Field(
        default="https://localhost:5001/api/",
        env='BACKEND_URL')


settings = Settings()
