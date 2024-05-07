using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace 재무인사Common.Model
{
    public class 거래처
    {
        public string 거래처코드 { get; set; }
        public string 상호 { get; set; } // 거래처명 대신 상호 사용
        public string 대표자명 { get; set; }
        public string 업태 { get; set; } // 업태 추가
        public string 종목 { get; set; } // 종목 추가
        public string 전화번호 { get; set; } // 기존 전화번호 필드 재사용
        public string Fax { get; set; } // Fax 번호 추가
        public string 검색창내용 { get; set; }
        public string 모바일번호 { get; set; } // 모바일 전화번호 추가
        public string 우편번호 { get; set; } // 주소1 우편번호
        public string 주소 { get; set; } // 주소1
        public string 홈페이지 { get; set; } // 홈페이지 URL 추가
        public string 담당자 { get; set; } // 담당자 이름 추가
        public string Email { get; set; } // Email 주소 추가

        public bool 사용구분 { get; set; }
        public string 이체정보Json { get; set; } // JSON 문자열로 이체정보 저장
                                             // 이체정보 직렬화/역직렬화
        [NotMapped]
        public 이체정보 이체정보
        {
            get => 이체정보Json == null ? null : JsonConvert.DeserializeObject<이체정보>(이체정보Json);
            set => 이체정보Json = JsonConvert.SerializeObject(value);
        }
    }

    public class 이체정보
    {
        public string 은행코드 { get; set; }
        public string 은행 { get; set; }
        public string 계좌번호 { get; set; }
        public string 예금주명 { get; set; }
        public string 적요1 { get; set; }
        public string 적요2 { get; set; }
        public bool 기본 { get; set; }
    }
}
