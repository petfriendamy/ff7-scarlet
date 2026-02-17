using System.Collections.ObjectModel;
using System.Globalization;
using System.Text;
using FF7Scarlet.AIEditor;

namespace FF7Scarlet.Shared
{
    public enum TextCommands : byte
    {
        Character = 0xEA,
        Item = 0xEB,
        Number = 0xEC,
        Target = 0xED,
        Previous = 0xEE,
        Attack = 0xEF,
        Target2 = 0xF0
    }

    public class FFText : IComparable
    {
        private ReadOnlyCollection<char> TEXT_MAP_EN = new char[] {
            ' ', '!', '\"', '#', '$', '%', '&', '\'', '(', ')', '*', '+', ',', '-', '.', '/',
            '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', ':', ';', '<', '=', '>', '?',
            '@', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O',
            'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', '[', '\\', ']', '^', '_',
            '`', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o',
            'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', '{', '?', '}', '~', '?',
            'Ä', 'Á', 'Ç', 'É', 'Ñ', 'Ö', 'Ü', 'á', 'à', 'â', 'ä', 'ã', 'å', 'ç', 'é', 'è',
            'ê', 'ë', 'í', 'ì', 'î', 'ï', 'ñ', 'ó', 'ò', 'ô', 'ö', 'õ', 'ú', 'ù', 'û', 'ü',
            '⌘', '°', '¢', '£', 'Ù', 'Û', '¶', 'ß', '®', '©', '™', '´', '¨', '≠', 'Æ', 'Ø',
            '∞', '±', '≤', '≥', '¥', 'µ', '∂', 'Σ', 'Π', 'π', '⌡', 'ª', 'º', 'Ω', 'æ', 'ø',
            '¿', '¡', '¬', '√', 'ƒ', '≈', '∆', '«', '»', '…', '?', 'À', 'Ã', 'Õ', 'Œ', 'œ',
            '–', '—', '“', '”', '‘', '’', '÷', '◊', 'ÿ', 'Ÿ', '⁄', '¤', '‹', '›', 'ﬁ', 'ﬂ',
            '■', '▪', '‚', '„', '‰', 'Â', 'Ê', 'Ë', 'Á', 'È', 'Í', 'Î', 'Ï', 'Ì', 'Ó', 'Ô',
            ' ', 'Ò', 'Ù', 'Û'
        }.AsReadOnly();

        private ReadOnlyCollection<char> TEXT_MAP_JP1 = new char[]
        {
            'バ', 'ば', 'ビ', 'び', 'ブ', 'ぶ', 'ベ', 'べ', 'ボ', 'ぼ', 'ガ', 'が', 'ギ', 'ぎ',
            'グ', 'ぐ', 'ゲ', 'げ', 'ゴ', 'ご', 'ザ', 'ざ', 'ジ', 'じ', 'ズ', 'ず', 'ゼ', 'ぜ',
            'ゾ', 'ぞ', 'ダ', 'だ', 'ヂ', 'ぢ', 'ヅ', 'づ', 'デ', 'で', 'ド', 'ど', 'ヴ', 'パ',
            'ぱ', 'ピ', 'ぴ', 'プ', 'ぷ', 'ペ', 'ぺ', 'ポ', 'ぽ', '0', '1', '2', '3', '4',
            '5', '6', '7', '8', '9', '、', '。', '　', 'ハ', 'は', 'ヒ', 'ひ', 'フ', 'ふ',
            'ヘ', 'へ', 'ホ', 'ほ', 'カ', 'か', 'キ', 'き', 'ク', 'く', 'ケ', 'け', 'コ', 'こ',
            'サ', 'さ', 'シ', 'し', 'ス', 'す', 'セ', 'せ', 'ソ', 'そ', 'タ', 'た', 'チ', 'ち',
            'ツ', 'つ', 'テ', 'て', 'ト', 'と', 'ウ', 'う', 'ア', 'あ', 'イ', 'い', 'エ', 'え',
            'オ', 'お', 'ナ', 'な', 'ニ', 'に', 'ヌ', 'ぬ', 'ネ', 'ね', 'ノ', 'の', 'マ', 'ま',
            'ミ', 'み', 'ム', 'む', 'メ', 'め', 'モ', 'も', 'ラ', 'ら', 'リ', 'り', 'ル', 'る',
            'レ', 'れ', 'ロ', 'ろ', 'ヤ', 'や', 'ユ', 'ゆ', 'ヨ', 'よ', 'ワ', 'わ', 'ン', 'ん',
            'ヲ', 'を', 'ッ', 'っ', 'ャ', 'ゃ', 'ュ', 'ゅ', 'ョ', 'ょ', 'ァ', 'ぁ', 'ィ', 'ぃ',
            'ゥ', 'ぅ', 'ェ', 'ぇ', 'ォ', 'ぉ', '！', '？', '『', '』', '．', '＋', 'A', 'B',
            'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P',
            'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', '・', '＊', 'ー', '～',
            '…', '％', '／', '：', '＆', '【', '】', '♥', '→', 'α', 'β', '「', '」', '（', '）',
            '\'', '－', '＝', '⑬'
        }.AsReadOnly();

        private ReadOnlyCollection<char> TEXT_MAP_JP2 = new char[]
        {
            '必', '殺', '技', '地', '獄', '火', '炎', '裁', '雷', '大', '怒', '斬', '鉄', '剣',
            '槍', '海', '衝', '聖', '審', '判', '転', '生', '改', '暗', '黒', '釜', '天', '崩',
            '壊', '零', '式', '自', '爆', '使', '放', '射', '臭', '息', '死', '宣', '告', '凶',
            '破', '晄', '撃', '画', '龍', '晴', '点', '睛', '超', '究', '武', '神', '覇', '癒',
            '風', '邪', '気', '封', '印', '吹', '烙', '星', '守', '護', '命', '鼓', '動', '福',
            '音', '掌', '打', '水', '面', '蹴', '乱', '闘', '合', '体', '疾', '迅', '明', '鏡',
            '止', '抜', '山', '蓋', '世', '血', '祭', '鎧', '袖', '一', '触', '者', '滅', '森',
            '羅', '万', '象', '装', '備', '器', '攻', '魔', '法', '召', '喚', '獣', '呼', '出',
            '持', '相', '手', '物', '確', '率', '弱', '投', '付', '与', '変', '化', '片', '方',
            '行', '決', '定', '分', '直', '前', '真', '似', '覚', '列', '後', '位', '置', '防',
            '御', '発', '回', '連', '続', '敵', '全', '即', '効', '果', '尾', '毒', '消', '金',
            '針', '乙', '女', '興', '奮', '剤', '鎮', '静', '能', '薬', '英', '雄', '榴', '弾',
            '右', '腕', '砂', '時', '計', '糸', '戦', '惑', '草', '牙', '南', '極', '冷', '結',
            '晶', '電', '鳥', '角', '有', '害', '質', '爪', '光', '月', '反', '巨', '目', '砲',
            '重', '力', '球', '空', '双', '野', '菜', '実', '兵', '単', '毛', '茶', '色', '髪'
        }.AsReadOnly();

        private ReadOnlyCollection<char> TEXT_MAP_JP3 = new char[]
        {
            '安', '香', '花', '会', '員', '蜂', '蜜', '館', '下', '着', '入', '先', '不', '子',
            '供', '屋', '商', '品', '景', '交', '換', '階', '模', '型', '部', '離', '場', '所',
            '仲', '間', '無', '制', '限', '殿', '様', '秘', '氷', '河', '図', '何', '材', '料',
            '雪', '上', '進', '事', '古', '代', '種', '鍵', '娘', '紙', '町', '住', '奥', '眠',
            '楽', '最', '初', '村', '雨', '釘', '陸', '吉', '揮', '叢', '雲', '軍', '異', '常',
            '通', '威', '父', '蛇', '矛', '青', '偃', '刀', '戟', '十', '字', '裏', '車', '円',
            '輪', '卍', '折', '鶴', '倶', '戴', '螺', '貝', '突', '銀', '玉', '正', '宗', '具',
            '甲', '烈', '属', '性', '吸', '収', '半', '減', '土', '高', '級', '状', '態', '縁',
            '闇', '睡', '石', '徐', '々', '的', '指', '混', '呪', '開', '始', '歩', '復', '盗',
            '小', '治', '理', '同', '速', '遅', '逃', '去', '視', '複', '味', '沈', '黙', '還',
            '倍', '数', '瀕', '取', '返', '人', '今', '差', '誰', '当', '拡', '散', '飛', '以',
            '外', '暴', '避', '振', '身', '中', '旋', '津', '波', '育', '機', '械', '擲', '炉',
            '新', '両', '本', '君', '洞', '内', '作', '警', '特', '殊', '板', '強', '穴', '隊',
            '族', '亡', '霊', '鎖', '足', '刃', '頭', '怪', '奇', '虫', '跳', '侍', '左', '首',
            '潜', '長', '親', '衛', '塔', '宝', '条', '像', '忍', '謎', '般', '見', '報', '充',
            '填', '完', '了', '銃', '元', '経', '験', '値', '終', '獲', '得', '名', '悲', '蛙',
            '操', '成', '費', '背', '切', '替', '割'
        }.AsReadOnly();

        private ReadOnlyCollection<char> TEXT_MAP_JP4 = new char[]
        {
            '由', '閉', '記', '憶', '選', '番', '街', '底', '忘', '都', '過', '艇', '路', '運',
            '搬', '船', '墓', '心', '港', '末', '宿', '西', '道', '艦', '家', '乗', '竜', '巻',
            '迷', '宮', '絶', '壁', '支', '社', '久', '件', '想', '秒', '予', '多', '落', '受',
            '組', '余', '系', '標', '起', '迫', '日', '勝', '形', '引', '現', '解', '除', '磁',
            '互', '口', '廃', '棄', '汚', '染', '液', '活', '令', '副', '隠', '主', '斉', '登',
            '温', '泉', '百', '段', '熱', '走', '急', '降', '奪', '響', '嵐', '移', '危', '戻',
            '遠', '吠', '軟', '骨', '言', '葉', '震', '叫', '噴', '舞', '狩', '粉', '失', '敗',
            '眼', '激', '盤', '逆', '鱗', '踏', '喰', '盾', '叩', '食', '凍', '退', '木', '吐',
            '線', '魅', '押', '潰', '曲', '翼', '教', '皇', '太', '陽', '界', '案', '挑', '援',
            '赤', '往', '殴', '意', '東', '北', '参', '知', '聞', '来', '仕', '別', '集', '信',
            '用', '思', '毎', '悪', '枯', '考', '然', '張', '好', '伍', '早', '各', '独', '配',
            '腐', '話', '帰', '永', '救', '感', '故', '売', '浮', '市', '加', '流', '約', '宇',
            '礼', '束', '母', '男', '年', '待', '宙', '立', '残', '俺', '少', '精', '士', '私',
            '険', '関', '倒', '休', '我', '許', '郷', '助', '要', '問', '係', '旧', '固', '荒',
            '稼', '良', '議', '導', '夢', '追', '説', '声', '任', '柱', '満', '未', '顔', '旅'
        }.AsReadOnly();

        private ReadOnlyCollection<char> TEXT_MAP_JP5 = new char[]
        {
            '友', '伝', '夜', '探', '対', '調', '民', '読', '占', '頼', '若', '学', '識', '業',
            '歳', '争', '苦', '織', '困', '答', '準', '恐', '認', '客', '務', '居', '他', '再',
            '幸', '役', '縮', '情', '豊', '夫', '近', '窟', '責', '建', '求', '迎', '貸', '期',
            '工', '算', '湿', '難', '保', '帯', '届', '凝', '笑', '向', '可', '遊', '襲', '申',
            '次', '国', '素', '題', '普', '密', '望', '官', '泣', '創', '術', '演', '輝', '買',
            '途', '浴', '老', '幼', '利', '門', '格', '原', '管', '牧', '炭', '彼', '房', '驚',
            '禁', '注', '整', '衆', '語', '証', '深', '層', '査', '渡', '号', '科', '欲', '店',
            '括', '坑', '酬', '緊', '研', '権', '書', '暇', '兄', '派', '造', '広', '川', '賛',
            '駅', '絡', '在', '党', '岸', '服', '捜', '姉', '敷', '胸', '刑', '谷', '痛', '岩',
            '至', '勢', '畑', '姿', '統', '略', '抹', '展', '示', '修', '酸', '製', '歓', '接',
            '障', '災', '室', '索', '扉', '傷', '録', '優', '基', '讐', '勇', '司', '境', '璧',
            '医', '怖', '狙', '協', '犯', '資', '設', '雇', '根', '億', '脱', '富', '躍', '純',
            '写', '病', '依', '到', '練', '順', '園', '総', '念', '維', '検', '朽', '圧', '補',
            '公', '働', '因', '朝', '浪', '祝', '恋', '郎', '勉', '春', '功', '耳', '恵', '緑',
            '美', '辺', '昇', '悩', '泊', '低', '酒', '影', '競', '二', '矢', '瞬', '希', '志'
        }.AsReadOnly();

        private ReadOnlyCollection<char> TEXT_MAP_JP6 = new char[]
        {
            '孫', '継', '団', '給', '抗', '違', '提', '断', '島', '栄', '油', '就', '僕', '存',
            '企', '比', '浸', '非', '応', '細', '承', '編', '排', '努', '締', '談', '趣', '埋',
            '営', '文', '夏', '個', '益', '損', '額', '区', '寒', '簡', '遣', '例', '肉', '博',
            '幻', '量', '昔', '臓', '負', '討', '悔', '膨', '飲', '妄', '越', '憎', '増', '枚',
            '皆', '愚', '療', '庫', '涙', '照', '冗', '壇', '坂', '訳', '抱', '薄', '義', '騒',
            '奴', '丈', '捕', '被', '概', '招', '劣', '較', '析', '繁', '殖', '耐', '論', '貴',
            '称', '千', '歴', '史', '募', '容', '噂', '壱', '胞', '鳴', '表', '雑', '職', '妹',
            '氏', '踊', '停', '罪', '甘', '健', '焼', '払', '侵', '頃', '愛', '便', '田', '舎',
            '孤', '晩', '清', '際', '領', '評', '課', '勤', '謝', '才', '偉', '誤', '価', '欠',
            '寄', '忙', '従', '五', '送', '周', '頑', '労', '植', '施', '販', '台', '度', '嫌',
            '諸', '習', '緒', '誘', '仮', '借', '輩', '席', '戒', '弟', '珍', '酔', '試', '騎',
            '霜', '鉱', '裕', '票', '券', '専', '祖', '惰', '偶', '怠', '罰', '熟', '牲', '燃',
            '犠', '快', '劇', '拠', '厄', '抵', '適', '程', '繰', '腹', '橋', '白', '処', '匹',
            '杯', '暑', '坊', '週', '秀', '看', '軽', '幕', '和', '平', '王', '姫', '庭', '観',
            '航', '横', '帳', '丘', '亭', '財', '律', '布', '規', '謀', '積', '刻', '陥', '類'
        }.AsReadOnly();

        private TextCommands[] commandList = Enum.GetValues<TextCommands>();
        private readonly byte[] data;

        public int Length
        {
            get { return data.Length; }
        }

        public FFText(byte[] data)
        {
            this.data = data;
        }

        public FFText(byte[] data, int length)
        {
            if (length < 1)
            {
                this.data = data;
            }
            else
            {
                this.data = new byte[length];
                if (data.Length > length) //truncate the string if it's too long
                {
                    var temp = new FFText(data);
                    data = temp.GetBytesTruncated();
                    if (data.Length > length) //still too long
                    {
                        data[length - 1] = 0xFF;
                    }
                }
                Array.Copy(data, this.data, Math.Min(length, data.Length));
            }
        }

        public FFText(string? str = null, int length = -1, bool isJapanese = false)
        {
            int i, j;
            if (str == null) //string is null
            {
                if (length == -1) { data = [0xFF]; }
                else
                {
                    data = new byte[length];
                    for (i = 0; i < length; ++i)
                    {
                        data[i] = 0xFF;
                    }
                }
            }
            else //get string
            {
                if (length == -1)
                {
                    length = str.Length + 1;
                }

                var text = new List<byte> { };
                var nameList = Enum.GetNames<CharacterNames>();

                for (i = 0; i < length; ++i)
                {
                    if (i < str.Length)
                    {
                        byte b = (byte)str[i];

                        if (b == (byte)'{' && i < length - 1) //variable
                        {
                            string temp = str.Substring(i + 1);
                            bool found = false;

                            for (j = 0; j < nameList.Length; ++j) //check for character names
                            {
                                if (temp.StartsWith(nameList[j].ToUpper()))
                                {
                                    text.Add((byte)TextCommands.Character);
                                    text.Add(0x00);
                                    text.Add((byte)j);
                                    i += nameList[j].Length + 1;
                                    found = true;
                                }
                                if (found) { break; }
                            }

                            if (!found) //no name found, so check for variables
                            {
                                for (j = 0; j < commandList.Length; ++j)
                                {
                                    var name = Enum.GetName(commandList[j]);
                                    if (name != null && temp.StartsWith(name.ToUpper()))
                                    {
                                        text.Add((byte)commandList[j]);
                                        text.Add(0xFF);
                                        text.Add(0xFF);
                                        i += name.Length + 1;
                                        found = true;
                                    }
                                    if (found) { break; }
                                }
                            }

                            //no matching variables, so assume regular character
                            if (!found && !isJapanese)
                            {
                                text.Add((byte)TEXT_MAP_EN.IndexOf('{'));
                            }
                        }
                        else //search text map
                        {
                            int pos;
                            if (isJapanese) //find if the character exists in any of the text maps
                            {
                                pos = TEXT_MAP_JP1.IndexOf(str[i]);
                                if (pos == -1)
                                {
                                    pos = TEXT_MAP_JP2.IndexOf(str[i]);
                                    if (pos >= 0)
                                        text.Add(0xFA);
                                    else
                                    {
                                        pos = TEXT_MAP_JP3.IndexOf(str[i]);
                                        if (pos >= 0)
                                            text.Add(0xFB);
                                        else
                                        {
                                            pos = TEXT_MAP_JP4.IndexOf(str[i]);
                                            if (pos >= 0)
                                                text.Add(0xFC);
                                            else
                                            {
                                                pos = TEXT_MAP_JP5.IndexOf(str[i]);
                                                if (pos >= 0)
                                                    text.Add(0xFD);
                                                else
                                                {
                                                    pos = TEXT_MAP_JP6.IndexOf(str[i]);
                                                    if (pos >= 0)
                                                        text.Add(0xFE);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            else
                                pos = TEXT_MAP_EN.IndexOf(str[i]);
                            if (pos >= 0)
                            {
                                text.Add((byte)pos);
                            }
                        }
                    }
                    else
                    {
                        text.Add(0xFF);
                    }
                }
                data = text.ToArray();
            }
        }

        public FFText(object? value) : this(value?.ToString()) { }

        public bool IsEmpty()
        {
            return ToString() == string.Empty;
        }

        public override string ToString()
        {
            return ToString(false);
        }

        public string ToString(bool isJapanese)
        {
            var currMap = TEXT_MAP_EN;
            bool pageLookup = false;
            if (isJapanese) currMap = TEXT_MAP_JP1;

            if (data == null)
            {
                return string.Empty;
            }
            else if (data.Length > 0)
            {
                var text = new List<char> { };
                for (int i = 0; i < data.Length; ++i)
                {
                    if (data[i] == 0xFF) //end of string
                    {
                        break;
                    }
                    else if (data[i] >= 0xFA && isJapanese) //JP text page
                    {
                        pageLookup = true;
                        switch (data[i])
                        {
                            case 0xFA:
                                currMap = TEXT_MAP_JP2;
                                break;
                            case 0xFB:
                                currMap = TEXT_MAP_JP3;
                                break;
                            case 0xFC:
                                currMap = TEXT_MAP_JP4;
                                break;
                            case 0xFD:
                                currMap = TEXT_MAP_JP5;
                                break;
                            case 0xFE:
                                currMap = TEXT_MAP_JP6;
                                break;
                        }
                    }
                    else
                    {
                        if (data[i] == 0xF8) //function, ignore this
                        {
                            i++;
                        }
                        else if (data[i] == (byte)TextCommands.Character) //character
                        {
                            int charID = data[i + 2];
                            var name = Enum.GetName((CharacterNames)charID);
                            if (name == null) { text.AddRange("{CHARACTER}"); }
                            else { text.AddRange("{" + name.ToUpper() + "}"); }
                            i += 2;
                        }
                        else if (commandList.Contains((TextCommands)data[i])) //variables
                        {
                            var name = Enum.GetName((TextCommands)data[i]);
                            if (name != null)
                            {
                                text.AddRange('{' + name.ToUpper() + '}');
                            }
                            i += 2;
                        }
                        else if (data[i] < currMap.Count) //regular text
                        {
                            text.Add(currMap[data[i]]);
                        }
                        else
                        {
                            text.Add('?');
                        }

                        //cancel page lookup
                        if (pageLookup)
                        {
                            currMap = TEXT_MAP_JP1;
                            pageLookup = false;
                        }
                    }
                }
                if (text.Count == 0)
                {
                    return string.Empty;
                }
                return new string(text.ToArray()).Trim();
            }
            return string.Empty;
        }

        public int ToInt()
        {
            int value;
            var provider = new CultureInfo("en-US");
            if (int.TryParse(ToString(), NumberStyles.HexNumber, provider, out value))
            {
                return value;
            }
            return -1;
        }

        public byte[] GetBytes(ParameterTypes type = ParameterTypes.String)
        {
            var singleByte = new byte[1];
            var threeByteInt = new byte[3];
            switch (type)
            {
                case ParameterTypes.OneByte:
                case ParameterTypes.ReadWrite:
                    singleByte[0] = (byte)ToInt();
                    return singleByte;
                case ParameterTypes.TwoByte:
                    return BitConverter.GetBytes((ushort)ToInt());
                case ParameterTypes.ThreeByte:
                    Array.Copy(BitConverter.GetBytes(ToInt()), threeByteInt, 3);
                    return threeByteInt;
                case ParameterTypes.Debug:
                    var str = ToString();
                    if (str == string.Empty) { return Array.Empty<byte>(); }
                    return Encoding.ASCII.GetBytes(str);
                default:
                    var copy = new byte[data.Length];
                    Array.Copy(data, copy, data.Length);
                    return copy;
            }
        }

        public byte[] GetBytes(int length, bool terminatedWithZero = false, bool padWithZero = false, bool addSpace = false)
        {
            var bytes = new byte[length];
            if (!terminatedWithZero && !padWithZero) //pad with null terminators
            {
                for (int i = 0; i < length; ++i)
                {
                    bytes[i] = 0xFF;
                }
            }
            var temp = GetBytesTruncated();
            int maxLength = Math.Min(length - 1, temp.Length - 1);
            Array.Copy(temp, bytes, maxLength);
            if (!terminatedWithZero)
            {
                int pos = maxLength;
                if (addSpace && maxLength < length - 1)
                {
                    bytes[pos] = 0;
                    pos++;
                }
                bytes[pos] = 0xFF;
            }
            return bytes;
        }

        public byte[] GetBytesTruncated()
        {
            var str = ToString().Trim();
            var copy = new FFText(str);
            return copy.GetBytes();
        }

        public int CompareTo(object? obj)
        {
            if (obj == null)
            {
                if (ToString() == null) { return 0; }
                else { throw new ArgumentNullException(); }
            }
            if (obj is FFText)
            {
                var text = obj as FFText;
                if (text == null)
                {
                    throw new ArgumentNullException();
                }
                else
                {
                    return CompareTo(text);
                }
            }
            else if (obj is string)
            {
                var str = ToString();
                return str.CompareTo(obj);
            }
            else if (obj is int)
            {
                return CompareTo((int)obj);
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public int CompareTo(FFText other)
        {
            var str = ToString();
            return str.CompareTo(other.ToString());
        }

        public static FFText GetTextFromByteArray(byte[] data, int pos, int length = -1)
        {
            var bytes = new List<byte>();
            using (var stream = new MemoryStream(data))
            using (var reader = new BinaryReader(stream))
            {
                stream.Seek(pos, SeekOrigin.Begin);
                byte b;
                do
                {
                    b = reader.ReadByte();
                    bytes.Add(b);
                } while (b != 0xFF);
            }
            return new FFText(bytes.ToArray(), length);
        }
    }
}
