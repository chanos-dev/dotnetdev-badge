## 🧷 dotnetdev badge:
![NET6.0](https://img.shields.io/badge/.NET-6.0-blueviolet) ![Tag](https://img.shields.io/github/v/tag/chanos-dev/dotnetdev-badge) ![License](https://img.shields.io/github/license/chanos-dev/dotnetdev-badge) ![commit](https://img.shields.io/github/last-commit/chanos-dev/dotnetdev-badge)
- `README.md`를 통해 [닷넷데브 포럼](https://forum.dotnetdev.kr) 프로필을 공유해보세요!
- 업데이트는 하루로 설정되어 있습니다.
  - `cache-control=max-age=86400`

- 사용모습

  ![dotnetdev profile](./assets/using.png)

--- 

### ⭐ badge 사용:

#### ✔ small badge:

##### API - v1 
```
https://profile.dotnetdev-badge.kr/api/v1/badge/small?id={id}&theme={Light,Dark,Dotnet}
```
> parameter - query string

| parameter |  default  | description                                                                |
| :------ | :-------: | :------------------------------------------------------------------------- |
| `id` | - | 닷넷데브 포럼 `사용자 이름` |
| `theme` | `Light` | 뱃지 테마 (`Light`, `Dark`, `Dotnet`) |

![dotnetdev profile](./assets/small-badge.png)

<details>
<summary>샘플</summary>

```
-- md
[![dotnetdev](https://profile.dotnetdev-badge.kr/api/v1/badge/small?id={id}&theme={theme})](https://forum.dotnetdev.kr/u/{id}/summary)

-- html 
<a href="https://forum.dotnetdev.kr/u/{id}/summary">
    <img src="https://profile.dotnetdev-badge.kr/api/v1/badge/small?id={id}&theme={theme}"/>
</a>
```
[![dotnetdev](https://profile.dotnetdev-badge.kr/api/v1/badge/small?id=chanos-dev&theme=Dark)](https://forum.dotnetdev.kr/u/chanos-dev/summary)

</details>   

#### ✔ medium badge:
##### API - v1
```
https://profile.dotnetdev-badge.kr/api/v1/badge/medium?id={id}&theme={Light,Dark,Dotnet}
```
> parameter - query string

| parameter |  default  | description                                                                |
| :------ | :-------: | :------------------------------------------------------------------------- |
| `id` | - | 닷넷데브 포럼 `사용자 이름` |
| `theme` | `Light` | 뱃지 테마 (`Light`, `Dark`, `Dotnet`) |

![dotnetdev profile](./assets/medium-badge.png)

<details>
<summary>샘플</summary>

```
-- md
[![dotnetdev](https://profile.dotnetdev-badge.kr/api/v1/badge/medium?id={id}&theme={theme})](https://forum.dotnetdev.kr/u/{id}/summary)

-- html 
<a href="https://forum.dotnetdev.kr/u/{id}/summary">
    <img src="https://profile.dotnetdev-badge.kr/api/v1/badge/medium?id={id}&theme={theme}"/>
</a>
```

[![dotnetdev](https://profile.dotnetdev-badge.kr/api/v1/badge/medium?id=chanos-dev&theme=Dark)](https://forum.dotnetdev.kr/u/chanos-dev/summary)

</details>