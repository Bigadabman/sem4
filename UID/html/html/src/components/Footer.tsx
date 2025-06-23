import * as React from "react";
import "./styles.css";

export function Footer() {
  return (
    <footer className="footer-container">
      <div className="flex footer-content flex-row mobile:flex-col-reverse items-center mobile:text-center">
        {/* Логотип */}
        
       
        {/* Основные секции */}
        <div className="flex flex-wrap justify-between mobile:flex-col-reverse w-full gap-6 mobile:items-center">
          <img
          src="https://cdn.builder.io/api/v1/image/assets/TEMP/3015f6c661e05ac248819e4daf89319d32d70161?placeholderIfAbsent=true"
          className="object-contain shrink-0 max-w-full aspect-square w-[196px] mobile:mt-8"
          alt="Footer logo"
        />
          {/* Контакты */}
          <div className="footer-section text-xs mobile:mt-6">
            <h3 className="text-base font-semibold">Контакты</h3>
            <div className="contact-item flex items-center mobile:justify-center">
              <img
                src="https://cdn.builder.io/api/v1/image/assets/TEMP/a8d274af2605931bffac24a813764ed25869fda8?placeholderIfAbsent=true"
                className="object-contain aspect-square w-[22px] mr-2"
                alt="Phone"
              />
              <div>+375 (12) 345-67-89</div>
            </div>
            <div className="contact-item flex items-center mobile:justify-center">
              <img
                src="https://cdn.builder.io/api/v1/image/assets/TEMP/2385ba1c4d1620cb8a1ec7c12d879f215ded4482?placeholderIfAbsent=true"
                className="object-contain aspect-square w-[22px] mr-2"
                alt="Telegram"
              />
              <div>телеграм</div>
            </div>
            <div className="contact-item flex items-center mobile:justify-center">
              <img
                src="https://cdn.builder.io/api/v1/image/assets/TEMP/a3b7e309ab000fdca867ea53cbe62da890066e02?placeholderIfAbsent=true"
                className="object-contain aspect-square w-[22px] mr-2"
                alt="VKontakte"
              />
              <div>Вконтакте</div>
            </div>
          </div>

          {/* Категории */}
          <nav className="footer-section mobile:mt-6">
            <h3 className="footer-title">Категории</h3>
            <div className="mt-5 text-sm">
              <div className="footer-link">Завтраки</div>
              <div className="footer-link">Обеды</div>
              <div className="footer-link">Ужины</div>
            </div>
          </nav>

          {/* Навигация */}
          <nav className="footer-section mobile:mt-6">
            <h3 className="footer-title">Навигация</h3>
            <div className="footer-links">
              <div className="footer-link text-sm">Моя книга</div>
              <div className="footer-link text-sm">Рецепты</div>
              <div className="footer-link text-sm">Добавить рецепт</div>
            </div>
          </nav>
        </div>
      </div>

      {/* Копирайт */}
      <p className="copyright text-center mt-8 mobile:mt-6">
        © 2025, Bigadabman. There is no rigthts reserved. This is part of the
        laboratory work.
      </p>
    </footer>
  );
}